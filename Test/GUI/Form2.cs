using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
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
            txtMSSV.Text = sv.mssv.ToString();
            txtNameSV.Text = sv.nameSV;
            txtDTB.Text = sv.dtb.ToString();
            cbbLopSH.Text = sv.LopSH.nameLop;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SV sV = new SV
            {
                mssv = Convert.ToInt32(txtMSSV.Text),
                nameSV = txtNameSV.Text,
                dtb = Convert.ToDouble(txtDTB.Text),
                lopId = helper.GetIdLop(cbbLopSH.Text)
            };
            if (txtMSSV.Enabled)
            {
                helper.AddSV(sV);
            }
            else
            {
                helper.EditSV(sV);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<string> listClass = helper.GetCBBLopSH();
            foreach(string s in listClass)
            {
                cbbLopSH.Items.Add(s);
            }
        }
    }
}
