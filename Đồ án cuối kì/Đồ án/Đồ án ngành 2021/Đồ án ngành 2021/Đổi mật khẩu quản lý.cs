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
    public partial class Đổi_mật_khẩu_quản_lý : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Đổi_mật_khẩu_quản_lý()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                cn.Open();                
                if (MessageBox.Show("Bạn muốn đổi mật khẩu quản lý ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    string Sql = "update DANGNHAP set MatKhau = '" + textBox2.Text + "' where TenDangNhap = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Không cập nhật");
                }
                cn.Close();
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu sai");
            }
        }
        public string TK2;
        private void Đổi_mật_khẩu_quản_lý_Load(object sender, EventArgs e)
        {
            textBox1.Text = TK2;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
