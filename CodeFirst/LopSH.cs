using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class LopSH
    {
        public LopSH()
        {
            SVs = new HashSet<SV>();
        }

        [Key]
        [StringLength(10)]
        public string ID_Lop { get; set; }

        [StringLength(20)]
        public string NameLop { get; set; }

        public virtual ICollection<SV> SVs { get; set; }

    }
}
