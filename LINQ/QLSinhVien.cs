using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LINQ
{
    public partial class QLSinhVien : DbContext
    {
        public QLSinhVien()
            : base("name=DBQLSinhVienConnectionString")
        {
        }

        public virtual DbSet<LopSH> LopSHes { get; set; }
        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LopSH>()
                .Property(e => e.ID_Lop)
                .IsFixedLength();

            modelBuilder.Entity<LopSH>()
                .Property(e => e.NameLop)
                .IsFixedLength();

            modelBuilder.Entity<SV>()
                .Property(e => e.MSSV)
                .IsFixedLength();

            modelBuilder.Entity<SV>()
                .Property(e => e.ID_Lop)
                .IsFixedLength();
        }
    }
}
