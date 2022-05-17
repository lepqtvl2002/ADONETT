using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
    public partial class Form1 : Form
    {
        QLSinhVien db = new QLSinhVien();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            /*var listSV = new QLSinhVien().SVs.ToList();
            dataGridView1.DataSource = listSV;*/
            /*var l1 = from p in db.SVs select p;
            dataGridView1.DataSource = l1.ToList();*/
            /*var l2 = db.SVs.Select(p => p);
            dataGridView1.DataSource = l2.ToList();*/
            /*var l1 = from p in db.SVs
                     where p.ID_Lop == "001"
                     select new { p.MSSV, p.NameSV, p.LopSH.NameLop };            
            dataGridView1.DataSource = l1.ToList();*/
            var l2 = db.SVs.Select(p => new { p.MSSV, p.NameSV, p.DTB, p.LopSH.NameLop });
            dataGridView1.DataSource = l2.ToList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            /*SV sv = new SV
            {
                MSSV = "102200399",
                NameSV = "Bui Van Thong",
                ID_Lop = "002",
                DTB = 1.1
            };
            db.SVs.Add(sv);
            db.SaveChanges();
            dataGridView1.DataSource = db.SVs.ToList();*/
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                string NameSV = dataGridView1.SelectedRows[0].Cells["NameSV"].Value.ToString();
                double DTB = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["DTB"].Value.ToString());
                string NameLop = dataGridView1.SelectedRows[0].Cells["NameLop"].Value.ToString();
                Form2 f = new Form2();
                f.Sender(MSSV, NameSV, DTB, NameLop);
                f.ShowDialog();
                /*var s = db.SVs.Where(p => p.MSSV == MSSV).FirstOrDefault();
                s.NameSV = "Da thay doi";
                db.SaveChanges();
                dataGridView1.DataSource = db.SVs.ToList();*/
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
                    db.SVs.Remove(s);
                    db.SaveChanges();
                    dataGridView1.DataSource = db.SVs.ToList();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var listLopSH = new QLSinhVien().LopSHes.Select(p => p.NameLop).ToList();
            foreach(string s in listLopSH)
            {
                cbbLop.Items.Add(s);
            }
        }
    }
}
