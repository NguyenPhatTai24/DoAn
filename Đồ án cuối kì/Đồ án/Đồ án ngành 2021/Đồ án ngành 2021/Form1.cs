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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quản_lý ql = new Quản_lý();
            ql.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nhân_viên nv = new Nhân_viên();
            nv.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public int s;
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string tk = textBox1.Text;
            string mk = textBox2.Text;
            string sql = "select * from DANGNHAP where TenDangNhap ='" + tk + "' and MatKhau='" + mk + "' and TenDangNhap like 'QL%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader da = cmd.ExecuteReader();
            if (da.Read() == true)
            {
                Quản_lý ql = new Quản_lý();
                ql.TK = textBox1.Text;
                ql.ShowDialog();
            }
            else
            {
                cn.Close();
                cn.Open();
                string tk1 = textBox1.Text;
                string mk1 = textBox2.Text;
                string sql2 = "select * from DANGNHAP where TenDangNhap ='" + tk1 + "' and MatKhau='" + mk1 + "' and TenDangNhap like 'NV%'";
                SqlCommand cmd2 = new SqlCommand(sql2, cn);
                SqlDataReader da2 = cmd2.ExecuteReader();
                if (da2.Read() == true)
                {
                    Nhân_viên nv = new Nhân_viên();
                    nv.TK = textBox1.Text;
                    nv.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu");
                }
                cn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(tb==DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
