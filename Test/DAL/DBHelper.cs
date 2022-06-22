using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DBHelper
    {
        QLSV db = new QLSV();
        public int sort_time = 0;
        public string[] listWork = {"mssv", "nameSV", "dtb", "lopSH"};
        public List<string> GetCBBLopSH()
        {
            var listClass = db.LopSHes.Select(p => p.nameLop).ToList();
            return listClass;
        }
        public SV FindSV(int mssv)
        {
            return db.SVs.Find(mssv);
        }
        public int GetIdLop(string namelop)
        {
            var lop = db.LopSHes.Where(p => p.nameLop == namelop).FirstOrDefault();
            return lop.lopId;
        }
        public Object GetAllRecord()
        {
            var list = db.SVs.Select(p => new { p.mssv, p.nameSV, p.dtb, p.LopSH.nameLop }).ToList();
            return list;
        }
        public Object GetListRecord(string lop)
        {
            if (lop == "All")
            {
                return GetAllRecord();
            }
            var list = db.SVs.Where(p => p.LopSH.nameLop == lop).Select(p => new { p.mssv, p.nameSV, p.dtb, p.LopSH.nameLop }).ToList();
            return list;
        }
        public void AddSV(SV sv)
        {
            db.SVs.Add(sv);
            db.SaveChanges();
        }
        public void DeleteSV(SV sv)
        {
            db.SVs.Remove(sv);
            db.SaveChanges();
        }
        public void EditSV(SV sv)
        {
            var svNew = db.SVs.Find(sv.mssv);
            svNew.nameSV = sv.nameSV;
            svNew.dtb = sv.dtb;
            svNew.lopId = sv.lopId;
            db.SaveChanges();
        }
        public Object SearchSV(string infor, string search_by)
        {
            var model = db.SVs;
            var context = db.SVs.Select(p => new { p.mssv, p.nameSV, p.dtb, p.LopSH.nameLop });
            if (search_by == listWork[0])
            {
                try
                {
                    int mssv = Convert.ToInt32(infor);
                    var list = context.Where(p => p.mssv == mssv).ToList();
                    return list;
                }
                catch
                {
                    
                }
            }
            else if (search_by == listWork[1])
            {
                var list = context.Where(p => p.nameSV.Contains(infor)).ToList();
                return list;
            }
            else if (search_by == listWork[2])
            {
                try
                {
                    double dtb = Convert.ToDouble(infor);
                    var list = context.Where(p => p.dtb == dtb).ToList();
                    return list;
                }
                catch
                {

                }
            }
            else if (search_by == listWork[3])
            {
                var list = context.Where(p => p.nameLop.Contains(infor)).ToList();
                return list;
            }
            return context.ToList();
        }
        public Object SortList(string sort_by, string lop)
        {
            var model = db.SVs;
            var context = db.SVs.Select(p => new { p.mssv, p.nameSV, p.dtb, p.LopSH.nameLop });
            if (lop != "All" && lop != null)
            {
                context = db.SVs.Where(p => p.LopSH.nameLop == lop).Select(p => new { p.mssv, p.nameSV, p.dtb, p.LopSH.nameLop });
            }

            if (sort_by == listWork[0])
            {
                var list = context.OrderBy(p => p.mssv).ToList();
                if (sort_time % 2 == 0)
                {
                    list = context.OrderByDescending(p => p.mssv).ToList();
                }
                return list;
            }
            else if (sort_by == listWork[1])
            {
                var list = context.OrderBy(p => p.nameSV).ToList();
                if (sort_time % 2 == 0)
                {
                    list = context.OrderByDescending(p => p.nameSV).ToList();
                }
                return list;
            }
            else if (sort_by == listWork[2])
            {
                var list = context.OrderBy(p => p.dtb).ToList();
                if (sort_time % 2 == 0)
                {
                    list = context.OrderByDescending(p => p.dtb).ToList();
                }
                return list;
            }
            else if (sort_by == listWork[3])
            {
                var list = context.OrderBy(p => p.nameLop).ToList();
                if (sort_time % 2 == 0)
                {
                    list = context.OrderByDescending(p => p.nameLop).ToList();
                }
                return list;
            }
            return context.ToList();
        }
    }
}
