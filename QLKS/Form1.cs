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

namespace QLKS
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-G30M9MA;Initial Catalog=QLPhongKhachSan;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Phong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMP.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtLP.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtGia.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtTang.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtTT.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loaiphong f = new Loaiphong();
            f.ShowDialog();
        }

        private void bookPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book f = new Book();
            f.ShowDialog();

        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khachhang f = new Khachhang();
            f.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
