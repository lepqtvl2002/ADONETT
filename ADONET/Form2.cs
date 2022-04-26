using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET
{
    public partial class Form2 : Form
    {
        string s = @"Data Source=DESKTOP-737MH8F\SQLEXPRESS;Initial Catalog=SQLDemo;Integrated Security=True";
        public delegate void InformationSV(string MSSV, string NameSV, double DTB, string LopSH);
        public InformationSV Sender;
        public Form2()
        {
            InitializeComponent();
            Sender = new InformationSV(GetInformationSV);
        }

        public void GetInformationSV(string MSSV, string NameSV, double DTB, string LopSH)
        {
            txtMSSVF2.Enabled = false;
            txtMSSVF2.Text = MSSV;
            txtNameSVF2.Text = NameSV;
            txtDTBF2.Text = DTB.ToString();
            cbbLopF2.Text = LopSH;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            string query = "select * from LopSH";
            foreach (string i in db.GetLopCBB(query))
            {
                cbbLopF2.Items.Add(i);
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            string st = db.GetID_Lop(cbbLopF2.Text);
            if (txtMSSVF2.Enabled == true)
            {
                string query = "insert into SV "
                + " values (\'" + txtMSSVF2.Text + "\',\'" + txtNameSVF2.Text + "\',"
                + txtDTBF2.Text + ",\'" + st + "\')";
                db.ExcuteDB(query);
            }
            else
            {
                string query = "update SV " +
                "set NameSV = \'" + txtNameSVF2.Text + "\' , DTB = " + Convert.ToDouble(txtDTBF2.Text)
                + ", ID_Lop = \'" + st + "\' WHERE MSSV = \'" + txtMSSVF2.Text + "\'";
                db.ExcuteDB(query);
            }
            
            Close();             
        }
    }
}
