using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2.Models
{
    public class MusicLabel
    {
        public int IDmusicLabel { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> albums { get; set; }
    }
}
