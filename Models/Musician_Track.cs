using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models
{
    public class Musician_Track
    {
        public int IdMusician { get; set; }
        public virtual Musician musician { get; set; }
        public int IdTrack { get; set; }
        public virtual Track track { get; set; }

    }
}
