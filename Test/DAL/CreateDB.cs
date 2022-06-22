using CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CreateDB :
        CreateDatabaseIfNotExists<QLSV>
    {
        protected override void Seed(QLSV context)
        {
            context.LopSHes.AddRange(new LopSH[]
            {
                new LopSH{lopId = 1, nameLop = "20T1"},
                new LopSH{lopId = 2, nameLop = "20T2"},
                new LopSH{lopId = 3, nameLop = "20DT1" },
                new LopSH{lopId = 4, nameLop = "20DT2"}
            });
            context.SVs.AddRange(new SV[]
            {
                new SV{mssv = 1, nameSV = "Tran Van A", dtb = 9, lopId = 1},
                new SV{mssv = 2, nameSV = "Nguyen Van B", dtb = 9.5, lopId = 2}
            });
        }
    }
}
