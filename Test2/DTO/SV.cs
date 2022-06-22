using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class SV
    {
        [Key]
        public int MSSV { get; set; }
        public string NameSV { get; set; }
        public int Id_Lop { get; set; }
        public bool GioiTinh { get; set; }
        public double DTB { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool IsPhoto { get; set; }
        public bool IsHocBa { get; set; }
        public bool IsCNDT { get; set; }
        public virtual LopSH LopSH { get; set; }
    }
}
