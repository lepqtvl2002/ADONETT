using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADONET
{
    public class DBHelper
    {
        private SqlConnection cnn;
        public DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable GetRecordSV(string query)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader r;
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn{ColumnName="MSSV", DataType = typeof(string)},
                new DataColumn{ColumnName="NameSV", DataType = typeof(string)},
                new DataColumn{ColumnName="DTB", DataType = typeof(double)},
                new DataColumn{ColumnName="ID_Lop", DataType = typeof(string)}

            });
            cnn.Open();
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                dt.Rows.Add(
                    r[0],
                    r[1],
                    Convert.ToDouble(r[2].ToString()),
                    r[3]);
            }
            cnn.Close();
            return dt;
        }
    }
}
