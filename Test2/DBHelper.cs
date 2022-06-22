using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class DBHelper
    {
        QLSV db = new QLSV();
        public int sort_time = 0;
        public string[] listWork = { "MSSV", "Name", "GioiTinh", "NgaySinh", "DiemTB" };
        public List<string> GetListClass()
        {
            List<string> list = db.LopSHes.Select(p => p.NameLop).ToList();
            return list;

        }
        public Object GetAllRecord()
        {
            var list = db.SVs.Select(p => new { p.MSSV, p.NameSV, p.GioiTinh, p.LopSH.NameLop, p.DTB, p.NgaySinh, p.IsPhoto, p.IsHocBa, p.IsCNDT }).ToList();
            return list;
        }
        public Object GetListRecord(string lop)
        {
            if (lop == "All" || lop == "")
            {
                return GetAllRecord();
            }
            var list = db.SVs.Where(p => p.LopSH.NameLop == lop).Select(p => new { p.MSSV, p.NameSV, p.GioiTinh, p.LopSH.NameLop, p.DTB, p.NgaySinh, p.IsPhoto, p.IsHocBa, p.IsCNDT }).ToList();
            return list;
        }
        public SV FindSV(int mssv)
        {
            return db.SVs.Find(mssv);
        }
        public int GetIdLop(string tenlop)
        {
            return db.LopSHes.Where(p => p.NameLop == tenlop).Select(p => p.Id_Lop).FirstOrDefault();
        }
        public void AddSV(SV sv)
        {
            db.SVs.Add(sv);
            db.SaveChanges();
        }
        public void DeleteSV(int mssv)
        {
            SV sv = db.SVs.Find(mssv);
            db.SVs.Remove(sv);
            db.SaveChanges();
        }
        public void EditSV(SV svNew)
        {
            SV sv = db.SVs.Find(svNew.MSSV);
            sv.NameSV = svNew.NameSV;
            sv.GioiTinh = svNew.GioiTinh;
            sv.IsPhoto = svNew.IsPhoto;
            sv.IsHocBa = svNew.IsHocBa;
            sv.IsCNDT = svNew.IsCNDT;
            sv.DTB = svNew.DTB;
            sv.Id_Lop = svNew.Id_Lop;
            sv.NgaySinh = svNew.NgaySinh;
            db.SaveChanges();
        }

        public Object SearchSV(string infor, string search_by)
        {
            var model = db.SVs;
            var context = model.Select(p => new { p.MSSV, p.NameSV, p.GioiTinh, p.LopSH.NameLop, p.DTB, p.NgaySinh, p.IsPhoto, p.IsHocBa, p.IsCNDT });
            if (search_by == listWork[0])
            {
                try
                {
                    int mssv = Convert.ToInt32(infor);
                    var list = context.Where(p => p.MSSV == mssv).ToList();
                    return list;
                }
                catch
                {

                }
            }
            else if (search_by == listWork[1])
            {
                var list = context.Where(p => p.NameSV.Contains(infor)).ToList();
                return list;
            }
            else if (search_by == listWork[2])
            {
                try
                {
                    bool gt = Convert.ToBoolean(infor);
                    var list = context.Where(p => p.GioiTinh == gt).ToList();
                    return list;
                }
                catch
                {

                }
            }
            else if (search_by == listWork[3])
            {
                try
                {
                    DateTime date = Convert.ToDateTime(infor);
                    var list = context.Where(p => p.NgaySinh == date).ToList();
                    return list;
                }
                catch
                {

                }
            }
            else if (search_by == listWork[4])
            {
                try
                {
                    double dtb = Convert.ToDouble(infor);
                    var list = context.Where(p => p.DTB == dtb).ToList();
                    return list;
                }
                catch
                {

                }
            }
            return context.ToList();
        }
        public Object SortSV(string lopsh, string sort_by)
        {
            var model = db.SVs;
            var context = model.Select(p => new { p.MSSV, p.NameSV, p.GioiTinh, p.LopSH.NameLop, p.DTB, p.NgaySinh, p.IsPhoto, p.IsHocBa, p.IsCNDT });
            if (lopsh != "All" && lopsh != "")
            {
                context = model.Select(p => new { p.MSSV, p.NameSV, p.GioiTinh, p.LopSH.NameLop, p.DTB, p.NgaySinh, p.IsPhoto, p.IsHocBa, p.IsCNDT }).Where(p => p.NameLop == lopsh);
            }
            
            if (sort_by == listWork[0])
            {
                var sort = context.OrderBy(p => p.MSSV);
                if (sort_time % 2 == 0)
                {
                    sort = context.OrderByDescending(p => p.MSSV);
                }
                return sort.ToList();
            }
            else if (sort_by == listWork[1])
            {
                var sort = context.OrderBy(p => p.NameSV);
                if (sort_time % 2 == 0)
                {
                    sort = context.OrderByDescending(p => p.NameSV);
                }
                return sort.ToList();
            }
            else if (sort_by == listWork[2])
            {
                var sort = context.OrderBy(p => p.GioiTinh);
                if (sort_time % 2 == 0)
                {
                    sort = context.OrderByDescending(p => p.GioiTinh);
                }
                return sort.ToList();
            }
            else if (sort_by == listWork[3])
            {
                var sort = context.OrderBy(p => p.NgaySinh);
                if (sort_time % 2 == 0)
                {
                    sort = context.OrderByDescending(p => p.NgaySinh);
                }
                return sort.ToList();
            }
            else if (sort_by == listWork[4])
            {
                var sort = context.OrderBy(p => p.DTB);
                if (sort_time % 2 == 0)
                {
                    sort = context.OrderByDescending(p => p.DTB);
                }
                return sort.ToList();
            }
            return context.ToList();
        }
    }
}
