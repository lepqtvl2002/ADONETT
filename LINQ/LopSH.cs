namespace LINQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopSH")]
    public partial class LopSH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopSH()
        {
            SVs = new HashSet<SV>();
        }

        [Key]
        [StringLength(10)]
        public string ID_Lop { get; set; }

        [StringLength(20)]
        public string NameLop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SV> SVs { get; set; }
    }
}
