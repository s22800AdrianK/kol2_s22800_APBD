using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
        public virtual Album album { get; set; }
        public virtual ICollection<Musician_Track> musician_tracks { get; set; }
    }
}
