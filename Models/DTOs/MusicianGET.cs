using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models.DTOs
{
    public class MusicianGET
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Nickname { get; set; }
        public virtual List<Models.DTOs.TrackGET> tracks { get; set; }
    }
}
