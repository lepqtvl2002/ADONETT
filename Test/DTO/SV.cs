using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SV
    {
        [Key]
        public int mssv { get; set; }
        public string nameSV { get; set; }
        public double dtb { get; set; }
        public int lopId { get; set; }
        public virtual LopSH LopSH { get; set; }
    }
}
