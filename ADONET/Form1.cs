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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//1CONNECTION 
            string s = @"Data Source=DESKTOP-737MH8F\SQLEXPRESS;Initial Catalog=SQLDemo;Integrated Security=True";
            DBHelper db = new DBHelper(s);
            string query = "select * from SV";
            dataGridView1.DataSource = db.GetRecordSV(query);

            /*SqlConnection cnn = new SqlConnection(s);
            string query = "select * from SV";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteReader();
            dataGridView1.DataSource = da;
            cnn.Close();
            MessageBox.Show(da.ToString());*/

            /*cnn.Open();
            cnn.Close();
            MessageBox.Show(cnn.State.ToString());*/



            //2COMMAND 
            //ExecuteScalar trả về các bản ghi bị tác động trong trường hợp ko thay đổi bản ghi
            //==> ĐẾM 
            /* string query = "select count(*) from SV";
             SqlCommand cmd = new SqlCommand(query,cnn);
             cnn.Open();
             int n = (int)cmd.ExecuteScalar();
             MessageBox.Show(n.ToString());
             cnn.Close();*/


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex >= 0)
            {
                string s = ((CBBItem)comboBox1.SelectedItem).Value
                    + ((CBBItem)comboBox1.SelectedItem).Text;
                MessageBox.Show(s);
            }
        }
    }
}
