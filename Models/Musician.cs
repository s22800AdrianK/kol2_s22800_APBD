using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Nickname { get; set; }
        public virtual ICollection<Musician_Track> musician_tracks { get; set; }
    }
}
