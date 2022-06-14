using Kol2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Services
{
    public interface IMusicianService
    {
        public Task<bool> DoesMusicianExist(int idMusician);
        public Task<Models.DTOs.MusicianGET> GetMusician(int idMusician);
        public Task DeleteMusician(int idMusician);
        public Task<List<Track>> GetTracks(int idMusician);
        public Task SaveChangesAsync();
        public Task Delete<T>(T entity) where T : class;
        public Task<List<Musician_Track>> GetMusician_Tracks(int idMusician);
    }
}
