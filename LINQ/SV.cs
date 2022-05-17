namespace LINQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SV")]
    public partial class SV
    {
        [Key]
        [StringLength(10)]
        public string MSSV { get; set; }

        [StringLength(30)]
        public string NameSV { get; set; }

        public double? DTB { get; set; }

        [StringLength(10)]
        public string ID_Lop { get; set; }

        public virtual LopSH LopSH { get; set; }
    }
}
