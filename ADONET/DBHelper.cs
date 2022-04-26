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
    public class DBHelper
    {
        private SqlConnection cnn;
        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }

        // insert, delete, update
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //
        public DataTable GetRecordSV(string query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader r;
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn{ColumnName="MSSV", DataType = typeof(string)},
                new DataColumn{ColumnName="NameSV", DataType = typeof(string)},
                new DataColumn{ColumnName="DTB", DataType = typeof(double)},
                new DataColumn{ColumnName="NameLop", DataType = typeof(string)}

            });
            
            cnn.Open();
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                dt.Rows.Add(
                    r["MSSV"],
                    r["NameSV"],
                    Convert.ToDouble(r["DTB"].ToString()),
                    r["NameLop"]);
            }
            cnn.Close();
            return dt;
        }

        public DataTable SearchRecordSV(string query, string MSSV, string name)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader r;
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn{ColumnName="MSSV", DataType = typeof(string)},
                new DataColumn{ColumnName="NameSV", DataType = typeof(string)},
                new DataColumn{ColumnName="DTB", DataType = typeof(double)},
                new DataColumn{ColumnName="NameLop", DataType = typeof(string)}

            });

            cnn.Open();
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (r["MSSV"].ToString().Contains(MSSV) && r["NameSV"].ToString().Contains(name))
                dt.Rows.Add(
                    r["MSSV"],
                    r["NameSV"],
                    Convert.ToDouble(r["DTB"].ToString()),
                    r["NameLop"]);
            }
            cnn.Close();
            return dt;
        }

        // load danh sach lop len combobox
        public List<string> GetLopCBB(string query)
        {
            List<string> list = new List<string>();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (list.Contains(reader["NameLop"].ToString())) ;
                else list.Add(reader["NameLop"].ToString());
            }
            //reader.Close();
            cnn.Close();
            return list;
        }

        //ExecuteScalar trả về các bản ghi bị tác động trong trường hợp ko thay đổi bản ghi
        //==> ĐẾM
        public int CountRecord(string query)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            count = (int)cmd.ExecuteScalar();
            cnn.Close();
            return count;
        }
        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public string GetID_Lop(string NameLop)
        {
            string id_lop = null;
            string query = "select * from LopSH";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader;
            cnn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["NameLop"].ToString() == NameLop)
                {                    
                    id_lop = reader["ID_Lop"].ToString();
                    break;
                }    
            }
            cnn.Close();
            return id_lop;
        }
    }
}
