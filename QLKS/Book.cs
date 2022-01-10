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
    public partial class Book : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-G30M9MA;Initial Catalog=QLPhongKhachSan;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from BookPhong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtMP.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTenKH.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtCMND.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtSN.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtNgay.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into BookPhong values('" + txtMaB.Text + "', '" + txtMP.Text + "','" + txtTenKH.Text + "','" + txtCMND.Text + "','"+txtSN.Text+"','"+txtNgay.Text+"')";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update BookPhong set MaPhong='" + txtMP.Text + "',TenKH='" + txtTenKH.Text + "',CMND='" + txtCMND.Text + "',SoNguoi='"+txtSN.Text+"',NgayDat='"+txtNgay.Text+"'  where CMND='" + txtCMND.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu này?", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from BookPhong where MaBook='" + txtMaB.Text + "' ";
                command.ExecuteNonQuery();
                loaddata();
            }
        }
    }
}
