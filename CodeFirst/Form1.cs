using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        QLSV db = new QLSV();
        static int sortCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getAllRecord();
            cbbLop.Text = "All";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            dataGridView1.DataSource = getAllRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var listClass = db.LopSHes.Select(p => p.NameLop).ToList();
            cbbLop.Items.Add("All");
            foreach (string s in listClass)
            {
                cbbLop.Items.Add(s);
            }
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLop.Text == "All")
            {
                dataGridView1.DataSource = getAllRecord();
            }
            else
            {
                dataGridView1.DataSource = getListRecord(cbbLop.Text);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                SV sv = db.SVs.Find(MSSV);
                Form2 f = new Form2();
                f.Sender(sv);
                f.ShowDialog();
                dataGridView1.DataSource = getAllRecord();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                    var s = db.SVs.Find(MSSV);
                    DialogResult = MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Xóa bản ghi", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.Yes)
                    {
                        db.SVs.Remove(s);
                        db.SaveChanges();
                        dataGridView1.DataSource = getAllRecord();
                    }
                    else
                    {
                        
                    }

                }
            }

        }
        
        public Object getAllRecord()
        {
            var list = db.SVs.Select(p => new {p.MSSV, p.NameSV, p.DTB, p.LopSH.NameLop}).ToList();
            return list;
        }
        public Object getListRecord(string lop)
        {
            if (lop == "All")
            {
                return getAllRecord();
            }
            var list = db.SVs.Where(p => p.LopSH.NameLop == lop).Select(p => new { p.MSSV, p.NameSV, p.DTB, p.LopSH.NameLop }).ToList();
            return list;
        }
        public Object sortList(string requirement)
        {
            var model = db.SVs;
            var context = model.Select(p => new { p.MSSV, p.NameSV, p.DTB, p.LopSH.NameLop });
            if (cbbLop.Text != "All" && cbbLop.Text != null)
            {
                context = model.Where(p => p.LopSH.NameLop == cbbLop.Text).Select(p => new { p.MSSV, p.NameSV, p.DTB, p.LopSH.NameLop });

            }            
            
            if (requirement == "MSSV")
            {
                var listSort = context.OrderBy(p => p.MSSV).ToList();
                if (sortCount % 2 == 0)
                {
                    listSort = context.OrderByDescending(p => p.MSSV).ToList();
                }           
                return listSort;
            }
            else if (requirement == "NameSV")
            {
                var listSort = context.OrderBy(p => p.NameSV).ToList();
                if (sortCount % 2 == 0)
                {
                    listSort = context.OrderByDescending(p => p.NameSV).ToList();
                }
                return listSort;
            }
            else if (requirement == "DTB")
            {
                var listSort = context.OrderBy(p => p.DTB).ToList();
                if (sortCount % 2 == 0)
                {
                    listSort = context.OrderByDescending(p => p.DTB).ToList();
                }
                return listSort;
            }
            var list = context.ToList();
            return list;
        }
        public Object searchList(string search_by, string content)
        {
            var model = db.SVs;
            var context = model.Select(p => new { p.MSSV, p.NameSV, p.DTB, p.LopSH.NameLop });
            if (search_by == "MSSV")
            {
                var list = context.Where(p => p.MSSV.Contains(content)).ToList();
                return list;
            }
            else if (search_by == "NameSV")
            {
                var list = context.Where(p => p.NameSV.Contains(content)).ToList();
                return list;
            }
            else if (search_by == "DTB")
            {
                try
                {
                    double dtb = Convert.ToDouble(content);
                    var list = context.Where(p => p.DTB == dtb).ToList();
                    return list;
                }
                catch
                {
                    MessageBox.Show("Loi du lieu!", "Error");
                }
                
            }
            else if (search_by == "LopSH")
            {
                var list = context.Where(p => p.NameLop.Contains(content)).ToList();
                return list;
            }
            return context.ToList();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sortCount ++;
            dataGridView1.DataSource = sortList(cbbSort.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = searchList(cbbSearch.Text, txtSearch.Text);
        }
    }
}
