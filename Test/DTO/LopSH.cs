using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class LopSH
    {
        public LopSH()
        {
            SVs = new HashSet<SV>();
        }
        [Key]
        public int lopId { get; set; }
        public string nameLop { get; set; }
        public virtual ICollection<SV> SVs { get; set; }
    }
}
