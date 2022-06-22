using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CreateDB:
        CreateDatabaseIfNotExists<QLSV>
        //DropCreateDatabaseIfModelChanges<QLSV>
        //DropCreateDatabaseAlways<QLSV>
    {
        protected override void Seed(QLSV context)
        {
            context.LopSHes.AddRange(new LopSH[]
            {
                new LopSH{ID_Lop = "1", NameLop = "20T1"},
                new LopSH{ID_Lop = "2", NameLop = "20T2"},
                new LopSH{ID_Lop = "3", NameLop = "20DT1"},
                new LopSH{ID_Lop = "4", NameLop = "20DT2"}
            }) ;
            context.SVs.AddRange(new SV[]
            {
                new SV{MSSV = "1", NameSV = "Bui Van Thong", DTB = 9.9, ID_Lop = "1"},
                new SV{MSSV = "2", NameSV = "Tran Van A", DTB = 9, ID_Lop= "2"}
            });
        }
    }
}
