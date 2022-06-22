using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class LopSH
    {
        public LopSH()
        {
            SVs = new HashSet<SV>();
        }
        [Key]
        public int Id_Lop { get; set; }
        public string NameLop { get; set; }
        public virtual ICollection<SV> SVs { get; set; }
    }
}
