using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form2 : Form
    {
        DBHelper helper = new DBHelper();
        public delegate void SendMessage(SV sv);
        public SendMessage Sender;
        public Form2()
        {
            InitializeComponent();
            Sender = new SendMessage(GetInformation);
        }
        private void GetInformation(SV sv)
        {
            txtMSSV.Enabled = false;
            txtMSSV.Text = sv.MSSV.ToString();
            txtName.Text = sv.NameSV;
            txtDTB.Text = sv.DTB.ToString();
            cbbLopSH.Text = sv.LopSH.NameLop;
            ckbPhoto.Checked = sv.IsPhoto;
            ckbHocBa.Checked = sv.IsHocBa;
            ckbCNDT.Checked = sv.IsCNDT;
            rdbMale.Checked = sv.GioiTinh;
            rdbFemale.Checked = !sv.GioiTinh;
            dateTimePicker1.Text = sv.NgaySinh.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<string> listClass = helper.GetListClass();
            foreach(string s in listClass)
            {
                cbbLopSH.Items.Add(s);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SV sv = new SV
            {
                MSSV = Convert.ToInt32(txtMSSV.Text),
                NameSV = txtName.Text,
                Id_Lop = helper.GetIdLop(cbbLopSH.Text),
                NgaySinh = dateTimePicker1.Value,
                DTB = Convert.ToDouble(txtDTB.Text),
                GioiTinh = rdbMale.Checked,
                IsPhoto = ckbPhoto.Checked,
                IsHocBa = ckbHocBa.Checked,
                IsCNDT = ckbCNDT.Checked
            };
            if (txtMSSV.Enabled)
            {
                helper.AddSV(sv);
            }
            else
            {
                helper.EditSV(sv);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
