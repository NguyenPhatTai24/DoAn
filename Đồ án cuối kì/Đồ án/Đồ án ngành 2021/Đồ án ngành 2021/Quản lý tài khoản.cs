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

namespace Đồ_án_ngành_2021
{
    public partial class Quản_lý_tài_khoản : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Quản_lý_tài_khoản()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Quản_lý ql = new Quản_lý();
            ql.ShowDialog();
        }
        public string TK1;
        private void Quản_lý_tài_khoản_Load(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select TenDangNhap as N'Tên Đăng Nhập' , MatKhau as N'Mật Khẩu' from DANGNHAP where TenDangNhap like 'NV%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
            dataGridView1.RowHeadersVisible = false;
            label7.Text = TK1;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Đổi_mật_khẩu_quản_lý dmkql = new Đổi_mật_khẩu_quản_lý();
            dmkql.TK2 = label7.Text;
            dmkql.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thêm tài khoản này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "Insert into DANGNHAP values('" + textBox1.Text + "','" + textBox2.Text + "')";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();


                string sql1 = "select TenDangNhap as N'Tên Đăng Nhập' , MatKhau as N'Mật Khẩu' from DANGNHAP where TenDangNhap like 'NV%'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                cn.Close();
            }
            else
            {
                MessageBox.Show("Không thêm");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thực hiện thao tác này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "Delete From DANGNHAP where TenDangNhap ='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string sql1 = "select TenDangNhap as N'Tên Đăng Nhập' , MatKhau as N'Mật Khẩu' from DANGNHAP where TenDangNhap like 'NV%'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                cn.Close();
            }
            else
            {
                MessageBox.Show("Không thực hiện");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đổi mật khẩu tài khoản này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "update DANGNHAP set MatKhau = '" + textBox2.Text + "' where TenDangNhap = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string sql1 = "select TenDangNhap as N'Tên Đăng Nhập' , MatKhau as N'Mật Khẩu' from DANGNHAP where TenDangNhap like 'NV%'";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                cn.Close();
            }
            else
            {
                MessageBox.Show("Không cập nhật");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
