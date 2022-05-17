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
    public partial class Form2 : Form
    {
        QLSinhVien db = new QLSinhVien();
        public delegate void InformationSV(string MSSV, string NameSV, double DTB, string LopSH);
        public InformationSV Sender;
        public Form2()
        {
            InitializeComponent();
            Sender = new InformationSV(GetInformationSV);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            var listLopSH = new QLSinhVien().LopSHes.Select(p => p.NameLop).ToList();
            foreach (string s in listLopSH)
            {
                cbbLopF2.Items.Add(s);
            }
        }
        public void GetInformationSV(string MSSV, string NameSV, double DTB, string LopSH)
        {
            txtMSSVF2.Enabled = false;
            txtMSSVF2.Text = MSSV;
            txtNameSVF2.Text = NameSV;
            txtDTBF2.Text = DTB.ToString();
            cbbLopF2.Text = LopSH;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var lopSH = db.LopSHes.Where(p => p.NameLop == cbbLopF2.Text).FirstOrDefault();
            string id_lop = lopSH.ID_Lop;
            if (txtMSSVF2.Enabled == true)
            {
                SV sv = new SV
                {
                    MSSV = txtMSSVF2.Text,
                    NameSV = txtNameSVF2.Text,
                    DTB = Convert.ToDouble(txtDTBF2.Text),
                    ID_Lop = id_lop
                };
                db.SVs.Add(sv);
                db.SaveChanges();
            }
            else
            {
                var s = db.SVs.Where(p => p.MSSV == txtMSSVF2.Text).FirstOrDefault();
                s.NameSV = txtNameSVF2.Text;
                s.DTB = Convert.ToDouble(txtDTBF2.Text);
                s.ID_Lop = id_lop;
                db.SaveChanges();
            }

            this.Close();
        }
    }
}
