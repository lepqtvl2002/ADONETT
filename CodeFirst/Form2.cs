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
    public partial class Form2 : Form
    {
        QLSV db = new QLSV();
        public delegate void SendMessage(SV sv);
        public SendMessage Sender;
        public Form2()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
        }
        private void GetMessage(SV sv)
        {
            txtMSSV.Enabled = false;
            txtMSSV.Text = sv.MSSV;
            txtNameSV.Text = sv.NameSV;
            txtDTB.Text = sv.DTB.ToString();
            cbbLopSH.Text = sv.LopSH.NameLop;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var listClass = db.LopSHes.Select(p => p.NameLop).ToList();
            foreach(string s in listClass)
            {
                cbbLopSH.Items.Add(s);
            }            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Enabled == true)
            {
                LopSH lop = db.LopSHes.Where(p => p.NameLop == cbbLopSH.Text).FirstOrDefault();
                SV sv = new SV
                {
                    MSSV = txtMSSV.Text,
                    NameSV = txtNameSV.Text,
                    DTB = Convert.ToDouble(txtDTB.Text),
                    ID_Lop = lop.ID_Lop
                };
                db.SVs.Add(sv);
                db.SaveChanges();
            }
            else
            {
                LopSH lop = db.LopSHes.Where(p => p.NameLop == cbbLopSH.Text).FirstOrDefault();
                SV sv = db.SVs.Find(txtMSSV.Text);
                sv.NameSV = txtNameSV.Text;
                sv.DTB = Convert.ToDouble(txtDTB.Text);
                sv.ID_Lop = lop.ID_Lop;
                db.SaveChanges();
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
