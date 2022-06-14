using Kol2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly MusicDBContext _context;
        public MusicianService(MusicDBContext medDBContext)
        {
            _context = medDBContext;
        }  
        
        public async Task Delete<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);
            Console.WriteLine(entry);
            entry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMusician(int idMusician)
        {
            var m = new Musician { IdMusician = idMusician };
            await Delete(m);
        }

        public async Task<bool> DoesMusicianExist(int idMusician)
        {
            return await _context.musicians.AnyAsync(e => e.IdMusician == idMusician);
        }

        public async Task<Models.DTOs.MusicianGET> GetMusician(int idMusician)
        {
            return await _context.musicians.Where(e => e.IdMusician == idMusician)
                .Select(e => new Models.DTOs.MusicianGET 
                { 
                    IdMusician = e.IdMusician,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Nickname = e.Nickname,
                    tracks = e.musician_tracks.Select(e => new Models.DTOs.TrackGET { TrackName = e.track.TrackName, Duration = e.track.Duration}).OrderBy(e => e.Duration).ToList()
                }).FirstAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Track>> GetTracks(int idMusician)
        {
            return await _context.musicians.Where(e => e.IdMusician == idMusician)
                  .Select(e => e.musician_tracks.Select(e => e.track).ToList()).FirstAsync();
        }

        public async Task<List<Musician_Track>> GetMusician_Tracks(int idMusician)
        {
            return await _context.musician_Tracks.Where(e => e.IdMusician == idMusician).ToListAsync();
        }
    }
}
