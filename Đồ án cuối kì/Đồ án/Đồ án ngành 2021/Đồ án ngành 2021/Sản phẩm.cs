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
    public partial class Sản_phẩm : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Sản_phẩm()
        {
            InitializeComponent();
        }
        public string tkk12;
        private void Sản_phẩm_Load(object sender, EventArgs e)
        {
            cn.Open();
            string sql14 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM";
            SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
            DataTable dt14 = new DataTable();
            da14.Fill(dt14);
            dataGridView1.DataSource = dt14;
            cn.Close();
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
            label6.Text = tkk12;
            dataGridView1.RowHeadersVisible = false;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        public int k;
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin sản phẩm");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn nhập sản phẩm này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Nhập thành công");
                    cn.Open();
                    string Sql = "Insert into SANPHAM values('" +textBox5.Text+ "',N'" +textBox6.Text+ "',N'" +textBox7.Text+ "','" +textBox9.Text+ "','" +textBox8.Text+ "','"+textBox1.Text+"','"+textBox10.Text+"','"+label6.Text+"')";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();

                    string sql14 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM";
                    SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
                    DataTable dt14 = new DataTable();
                    da14.Fill(dt14);
                    dataGridView1.DataSource = dt14;

                    k = dataGridView1.Rows.Count - 1;
                    label5.Text = k.ToString();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Không nhập nữa");
                }
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView1.CurrentCell.RowIndex;
            textBox5.Text = (string)dataGridView1.Rows[t].Cells[0].Value;
            textBox6.Text = (string)dataGridView1.Rows[t].Cells[1].Value;
            textBox7.Text = (string)dataGridView1.Rows[t].Cells[2].Value;
            textBox9.Text = dataGridView1.Rows[t].Cells[3].Value.ToString();
            textBox8.Text = (string)dataGridView1.Rows[t].Cells[4].Value;
            textBox1.Text = dataGridView1.Rows[t].Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.Rows[t].Cells[6].Value.ToString();
            cn.Open();
            string sql14 = "select LEFT(MaSP,4) from SANPHAM where MaSP like '"+textBox5.Text+ "%'";
            SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
            DataTable dt14 = new DataTable();
            da14.Fill(dt14);
            cn.Close();
            pictureBox1.Image = Image.FromFile("D://Hình sản phẩm//" +dt14.Rows[0][0].ToString()+ ".jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Bạn chưa có mã sản phẩm");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xóa sản phẩm này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Xóa thành công");
                    cn.Open();
                    string Sql = "Delete From SANPHAM where MaSP = '" + textBox5.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();

                    string sql14 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM";
                    SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
                    DataTable dt14 = new DataTable();
                    da14.Fill(dt14);
                    dataGridView1.DataSource = dt14;
                    cn.Close();
                    k = dataGridView1.Rows.Count - 1;
                    label5.Text = k.ToString();
                }
                else
                {
                    MessageBox.Show("Không xóa nữa");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin sản phẩm");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn chỉnh sửa thông tin sản phẩm này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Chỉnh sửa thành công");
                    cn.Open();

                    string Sql = "update SANPHAM set TenSP = N'" + textBox6.Text + "',NhanHieu = N'" + textBox7.Text + "',KhuyenMai = '" + textBox9.Text + "',KichCo = '" + textBox8.Text + "',Gia = '" + textBox1.Text + "',TonKho = '" + textBox10.Text + "' where TenDangNhap ='" + label6.Text + "' and MaSP= '" + textBox5.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();

                    string sql14 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM";
                    SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
                    DataTable dt14 = new DataTable();
                    da14.Fill(dt14);
                    dataGridView1.DataSource = dt14;

                    k = dataGridView1.Rows.Count - 1;
                    label5.Text = k.ToString();
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Không chỉnh sửa");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();
            if(radioButton2.Checked == true)
            {
                string sql15 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where TonKho > 0";
                SqlDataAdapter da15 = new SqlDataAdapter(sql15, cn);
                DataTable dt15 = new DataTable();
                da15.Fill(dt15);
                dataGridView1.DataSource = dt15;
            }
            else if (radioButton1.Checked == true)
            {
                string sql16 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where TonKho = 0";
                SqlDataAdapter da16 = new SqlDataAdapter(sql16, cn);
                DataTable dt16 = new DataTable();
                da16.Fill(dt16);
                dataGridView1.DataSource = dt16;
            }
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
            cn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (radioButton3.Checked == true)
            {
                string sql15 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where KhuyenMai > 0";
                SqlDataAdapter da15 = new SqlDataAdapter(sql15, cn);
                DataTable dt15 = new DataTable();
                da15.Fill(dt15);
                dataGridView1.DataSource = dt15;
            }
            else if (radioButton4.Checked == true)
            {
                string sql16 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where KhuyenMai = 0";
                SqlDataAdapter da16 = new SqlDataAdapter(sql16, cn);
                DataTable dt16 = new DataTable();
                da16.Fill(dt16);
                dataGridView1.DataSource = dt16;
            }
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql14 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM";
            SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
            DataTable dt14 = new DataTable();
            da14.Fill(dt14);
            dataGridView1.DataSource = dt14;
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
            cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            if (comboBox1.Text == "Quần Áo")
            {
                string sql16 = "select MaSP from SANPHAM where MaSP like 'AQ%'";
                SqlDataAdapter da16 = new SqlDataAdapter(sql16, cn);
                DataTable dt16 = new DataTable();
                da16.Fill(dt16);
                comboBox3.DataSource = dt16;
                comboBox3.DisplayMember = "MaSP";
                comboBox3.ValueMember = "MaSP";

                string sql166 = "select DISTINCT NhanHieu from SANPHAM where MaSP like 'AQ%'";
                SqlDataAdapter da166 = new SqlDataAdapter(sql166, cn);
                DataTable dt166 = new DataTable();
                da166.Fill(dt166);
                comboBox2.DataSource = dt166;
                comboBox2.DisplayMember = "NhanHieu";
                comboBox2.ValueMember = "NhanHieu";

                string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where MaSP like 'AQ%'";
                SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
                DataTable dt17 = new DataTable();
                da17.Fill(dt17);
                dataGridView1.DataSource = dt17;
            }
            else if (comboBox1.Text == "Giày")
            {
                string sql19 = "select MaSP from SANPHAM where MaSP like 'GG%'";
                SqlDataAdapter da19 = new SqlDataAdapter(sql19, cn);
                DataTable dt19 = new DataTable();
                da19.Fill(dt19);
                comboBox3.DataSource = dt19;
                comboBox3.DisplayMember = "MaSP";
                comboBox3.ValueMember = "MaSP";

                string sql166 = "select DISTINCT NhanHieu from SANPHAM where MaSP like 'GG%'";
                SqlDataAdapter da166 = new SqlDataAdapter(sql166, cn);
                DataTable dt166 = new DataTable();
                da166.Fill(dt166);
                comboBox2.DataSource = dt166;
                comboBox2.DisplayMember = "NhanHieu";
                comboBox2.ValueMember = "NhanHieu";

                string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where MaSP like 'GG%'";
                SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
                DataTable dt17 = new DataTable();
                da17.Fill(dt17);
                dataGridView1.DataSource = dt17;
            }
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
            cn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where MaSP = '"+comboBox3.Text+"'";
            SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
            DataTable dt17 = new DataTable();
            da17.Fill(dt17);
            dataGridView1.DataSource = dt17;
            cn.Close();
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where NhanHieu = '" + comboBox2.Text + "'";
            SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
            DataTable dt17 = new DataTable();
            da17.Fill(dt17);
            dataGridView1.DataSource = dt17;
            cn.Close();
            k = dataGridView1.Rows.Count - 1;
            label5.Text = k.ToString();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
