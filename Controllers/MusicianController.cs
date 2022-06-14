using Kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _service;

        public MusicianController(IMusicianService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getMusicianAsync(int id)
        {
            if (!await _service.DoesMusicianExist(id)) return StatusCode(400, "Musician doesn't exist");
            return Ok(await _service.GetMusician(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicianAsync(int id)
        {
            if (!await _service.DoesMusicianExist(id)) return StatusCode(400, "Musician doesn't exist");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) 
            {
                try
                {
                    var tracks = await _service.GetTracks(id);

                    if(tracks.Where(e => e.IdMusicAlbum != null).FirstOrDefault()!=null)
                        return StatusCode(400, "You are not allowed to delete musician with tracks on album");

                    var musician_tracks = await _service.GetMusician_Tracks(id);
                    foreach (var mt in musician_tracks)
                    {
                        await _service.Delete(mt);
                    }

                    await _service.DeleteMusician(id);
                    scope.Complete();
                }
                catch (Exception)
                {
                    return Problem("Internal Server Error");
                }
            }
            await _service.SaveChangesAsync();
            return NoContent();
        }
    }
}
