using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class SV
    {
        [Key][Required]
        [StringLength(9)]
        public string MSSV { get; set; }

        [StringLength(30)]
        public string NameSV { get; set; }

        public double? DTB { get; set; }

        [StringLength(10)]
        public string ID_Lop { get; set; }

        public virtual LopSH LopSH { get; set; }
    }
}
