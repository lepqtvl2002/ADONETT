using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADONET
{
    public partial class Form1 : Form
    {
        int index = 0;
        string s = @"Data Source=DESKTOP-737MH8F\SQLEXPRESS;Initial Catalog=SQLDemo;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            string query = "select * from LopSH";
            foreach (string i in db.GetLopCBB(query))
            {
                cbbLop.Items.Add(i);
                cbbSearchLop.Items.Add(i);
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {//1CONNECTION 
            DBHelper db = new DBHelper(s);
            string query = "select * from SV inner join LopSH on SV.ID_Lop = LopSH.ID_Lop";
            dataGridView1.DataSource = db.GetRecordSV(query);
            cbbLop.Text = "";
            txtSoBanGhi.Text = "";
            
            //ExecuteNonQuery trả về các bản ghi bị tác động trong trường hợp bản ghi bị
            //thay đổi bản ghi ==> insert , delete, update

            /*string query = "INSERT INTO SV values('102200389','thang','100','2')";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();*/

            /* string query = "DELETE FROM SV WHERE NameSV = 'paa'";
             SqlCommand cmd = new SqlCommand(query, cnn);
             cnn.Open();
             cmd.ExecuteNonQuery();
             cnn.Close();*/

            /*string query = "UPDATE SV " +
                "SET NameSV ='Dac Thai' ,DTB = '10' " +
                "WHERE MSSV='102200387'";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();*/


            /* //ExecuteReader --> dùng cho select .... where
             string query = "select * from LopSH";
             SqlCommand cmd = new SqlCommand(query, cnn);
             cnn.Open();
             SqlDataReader r = cmd.ExecuteReader();
             while(r.Read())
             {           
              comboBox1.Items.Add(new CBBItem
                 {
                     Value = Convert.ToInt32(r["ID_Lop"].ToString()),
                     Text = r["NameLop"].ToString()
             });
             }
             cnn.Close();*/




            //Dataset --> mảng nhiều Datatable 
            //cầu nối trung gian CSDL <-> DataSet
            //SqlDataAdapter  Fill :  đổ dữ liệu từ CSDL --> Dataset

            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            string query = "select MSSV, NameSV, DTB, NameLop from SV inner join LopSH" +
                " on SV.ID_Lop = LopSH.ID_Lop";
            dataGridView1.DataSource = db.GetRecords(query);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            string str = cbbLop.Text;
            string giveRecord = "select * from ";
            string countRecord = "select count(*) from ";
            string query = giveRecord +
                "SV inner join LopSH on SV.ID_Lop = LopSH.ID_Lop " +
                "where NameLop = "
                + "\'" + str + "\'";
            dataGridView1.DataSource = db.GetRecordSV(query);
            query = query.Replace(giveRecord, countRecord);
            txtSoBanGhi.Text = db.CountRecord(query).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);

            string query = "select count(*) from SV";
            MessageBox.Show(db.CountRecord(query).ToString(), "So ban ghi");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);

            string Lop = cbbSearchLop.Text;
            if (Lop != "") Lop = "where NameLop = " + "\'" + Lop + "\'";
            string MSSV = txtSearchMSSV.Text;
            string Name = txtSearchName.Text;
            string query = "select * from " +
                "SV inner join LopSH on SV.ID_Lop = LopSH.ID_Lop "
                + Lop;
            dataGridView1.DataSource = db.SearchRecordSV(query, MSSV, Name);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            Form2 f = new Form2();
            f.ShowDialog();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper(s);
            int i = dataGridView1.SelectedRows.Count;
            if (i > 0)
            {
                DialogResult result = MessageBox.Show("Ban muon xoa cac ban ghi duoc chon?", "Xac nhan", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int tmp = 0;
                    while (i > tmp)
                    {
                        int index = dataGridView1.SelectedRows[tmp].Index;
                        string MSSV = dataGridView1.Rows[index].Cells["MSSV"].Value.ToString();
                        string query = "delete from SV where MSSV = \'" + MSSV + "\'";
                        db.ExcuteDB(query);
                        tmp++;
                        MessageBox.Show("Da xoa " + MSSV);
                    }

                }
            }
            else
            {
                MessageBox.Show("Hay chon hang de xoa!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string mssv = dataGridView1.Rows[index].Cells["MSSV"].Value.ToString();
            string namesv = dataGridView1.Rows[index].Cells["NameSV"].Value.ToString();
            double dtb = Convert.ToDouble(dataGridView1.Rows[index].Cells["DTB"].Value.ToString());
            string lopsh = dataGridView1.Rows[index].Cells["NameLop"].Value.ToString();

            Form2 f = new Form2();
            f.Sender(mssv, namesv, dtb,lopsh);
            f.ShowDialog();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = e.RowIndex;
            string mssv = dataGridView1.Rows[index].Cells["MSSV"].Value.ToString();
            string namesv = dataGridView1.Rows[index].Cells["NameSV"].Value.ToString();
            double dtb = Convert.ToDouble(dataGridView1.Rows[index].Cells["DTB"].Value.ToString());
            string lopsh = dataGridView1.Rows[index].Cells["NameLop"].Value.ToString();
            
            Form2 f = new Form2();
            f.Sender(mssv, namesv, dtb, lopsh);
            f.ShowDialog();
        }
    }
}
