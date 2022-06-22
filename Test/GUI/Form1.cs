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
    public partial class Form1 : Form
    {
        DBHelper helper = new DBHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = helper.GetAllRecord();
            cbbLopSH.Text = "All";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(string s in helper.listWork)
            {
                cbbSearch.Items.Add(s);
                cbbSort.Items.Add(s);
            }
            cbbLopSH.Items.Add("All");
            List<string> listCLass = helper.GetCBBLopSH();
            foreach(string s in listCLass)
            {
                cbbLopSH.Items.Add(s);
            }
        }

        private void cbbLopSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLopSH.Text == "All")
            {
                dataGridView1.DataSource = helper.GetAllRecord();
            }
            else
            {
                dataGridView1.DataSource=helper.GetListRecord(cbbLopSH.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            dataGridView1.DataSource = helper.GetAllRecord();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form2 f = new Form2();
                int mssv = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["mssv"].Value.ToString());
                SV sv = helper.FindSV(mssv);
                f.Sender(sv);
                f.ShowDialog();
            }
            dataGridView1.DataSource = helper.GetListRecord(cbbLopSH.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int mssv = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["mssv"].Value.ToString());
                    SV sv = helper.FindSV(mssv);
                    DialogResult = MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Xóa bản ghi", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.Yes)
                    {
                        helper.DeleteSV(sv);
                        dataGridView1.DataSource = helper.GetAllRecord();
                    }
                    else
                    {

                    }

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = helper.SearchSV(txtSearch.Text, cbbSearch.Text);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            helper.sort_time++;
            dataGridView1.DataSource = helper.SortList(cbbSort.Text, cbbLopSH.Text);
        }
    }
}
