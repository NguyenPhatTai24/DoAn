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
    public partial class Quản_lý_nhân_viên : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Quản_lý_nhân_viên()
        {
            InitializeComponent();
        }
        public string dknn;
        public string nam = "Nam";
        public string nu = "Nữ";
        public string qll;
        private void Quản_lý_nhân_viên_Load(object sender, EventArgs e)
        {
            label11.Text = qll;
            cn.Open();
            string sql = "select TenDangNhap as 'Mã nhân viên', HoTen as 'Họ tên',GioiTinh as 'Giới tính' ,CMND,NamSinh as 'Năm sinh',Email,Sdt as 'Số điện thoại', Stk as 'Số tài khoản',QuanLy as 'Quản lý' from NHANVIEN";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            string sql1 = "select TenDangNhap from DANGNHAP where TenDangNhap like 'NV%'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            textBox8.DataSource = dt1;
            textBox8.DisplayMember = "TenDangNhap";
            textBox8.ValueMember = "TenDangNhap";
            dataGridView1.RowHeadersVisible = false;
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                dknn = "Nam";
            else if (radioButton2.Checked == true)
                dknn = "Nữ";
            cn.Open();
            label11.Text = qll;
            if (MessageBox.Show("Bạn muốn thêm nhân viên này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                string Sql = "Insert into NHANVIEN values('" + textBox8.Text + "',N'" + textBox1.Text + "',N'" + dknn + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + label11.Text + "')";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string sql1 = "select TenDangNhap as 'Mã nhân viên', HoTen as 'Họ tên',GioiTinh as 'Giới tính' ,CMND,NamSinh as 'Năm sinh',Email,Sdt as 'Số điện thoại', Stk as 'Số tài khoản',QuanLy as 'Quản lý' from NHANVIEN";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }
            else
            {
                MessageBox.Show("Không thêm");
            }
            cn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cn.Open();
            label11.Text = qll;
            if (radioButton1.Checked == true)
                dknn = "Nam";
            else if (radioButton2.Checked == true)
                dknn = "Nữ";
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox8.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                if(row.Cells[2].Value.ToString() == nam)
                radioButton1.Checked = true;
                else
                radioButton2.Checked = true;
                textBox7.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox4.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                pictureBox1.Image = Image.FromFile("D://Hình nhân sự//" + textBox8.Text + ".jpg");
            }
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label11.Text = qll;
            if (radioButton1.Checked == true)
                dknn = "Nam";
            else if (radioButton2.Checked == true)
                dknn = "Nữ";
            if (MessageBox.Show("Bạn muốn xóa nhân viên này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "Delete From NHANVIEN where TenDangNhap ='" + textBox8.Text + "' and CMND = '" + textBox7.Text + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string sql1 = "select TenDangNhap as 'Mã nhân viên', HoTen as 'Họ tên',GioiTinh as 'Giới tính' ,CMND,NamSinh as 'Năm sinh',Email,Sdt as 'Số điện thoại', Stk as 'Số tài khoản',QuanLy as 'Quản lý' from NHANVIEN";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                cn.Close();
            }
            else
            {
                MessageBox.Show("Không xóa");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label11.Text = qll;
            if (radioButton1.Checked == true)
                dknn = "Nam";
            else if (radioButton2.Checked == true)
                dknn = "Nữ";
            if (MessageBox.Show("Bạn muốn cập nhật thông tin nhân viên này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "update NHANVIEN set  TenDangNhap= '" + textBox8.Text + "',HoTen = N'" + textBox1.Text + "',GioiTinh = N'" + dknn + "',CMND = '" + textBox7.Text + "',NamSinh = '" + textBox3.Text + "',Email = '" + textBox6.Text + "',Sdt = '" + textBox4.Text + "',Stk = '" + textBox5.Text + "' where TenDangNhap ='" + textBox8.Text + "' and CMND = '" + textBox7.Text + "'and QuanLy ='" + label11.Text + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();



                string sql1 = "select TenDangNhap as 'Mã nhân viên', HoTen as 'Họ tên',GioiTinh as 'Giới tính' ,CMND,NamSinh as 'Năm sinh',Email,Sdt as 'Số điện thoại', Stk as 'Số tài khoản',QuanLy as 'Quản lý' from NHANVIEN";
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

        private void textBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
