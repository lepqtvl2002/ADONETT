using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class CreateDB:
        CreateDatabaseIfNotExists<QLSV>
    {
        protected override void Seed(QLSV context)
        {
            context.LopSHes.AddRange( new LopSH[]
            {
                new LopSH {Id_Lop = 1, NameLop = "20T1"},
                new LopSH {Id_Lop = 2, NameLop = "20T2"}
            });
            context.SVs.Add(new SV
            {
                MSSV = 1,
                NameSV = "Tran Van A",
                Id_Lop = 1,
                GioiTinh = true,
                DTB = 9,
                NgaySinh = Convert.ToDateTime("10-10-2002"),
                IsPhoto = true,
                IsHocBa = true,
                IsCNDT = false
            });
        }
    }
}
