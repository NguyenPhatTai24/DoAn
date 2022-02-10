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
    public partial class Quản_lý_lương : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Quản_lý_lương()
        {
            InitializeComponent();
        }
        public string tkkk;
        public int s = 0, h;
        public int k;
        public int ee;
        public int bb;
        public int kk;
        public int gg;
        private void Quản_lý_lương_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
            cn.Open();
            string sql1 = "Select NgayLe as 'Ngày lễ' from LE";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;

            string sql = "select TenDangNhap from DANGNHAP where TenDangNhap like 'NV%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenDangNhap";
            comboBox1.ValueMember = "TenDangNhap";
            comboBox1.SelectedIndex = -1;

            string sql10 = "Select L.TenDangNhap as 'Mã nhân viên',N.HoTen as 'Họ tên',concat(L.Luong,N' đồng')  as 'Lương theo ca' from LUONGTHEOCA L, NHANVIEN N where L.TenDangNhap = N.TenDangNhap";
            SqlDataAdapter da10 = new SqlDataAdapter(sql10, cn);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            dataGridView2.DataSource = dt10;

            string sql101 = "Select L.TenDangNhap as 'Mã nhân viên',N.HoTen as 'Họ tên',L.Luong  as 'Lương theo ca' from LUONGTHEOCA L, NHANVIEN N where L.TenDangNhap = N.TenDangNhap";
            SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
            DataTable dt101 = new DataTable();
            da101.Fill(dt101);
            dataGridView5.DataSource = dt101;

            label7.Text = tkkk;


                cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();

            if (MessageBox.Show("Bạn muốn thêm ngày lễ ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                string Sql = "Insert into LE values('" + dateTimePicker1.Value + "')";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Không thêm");
            }
            string sql1 = "Select NgayLe as 'Ngày lễ' from LE";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.Open();

            if (MessageBox.Show("Bạn muốn xóa ngày lễ này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                string Sql = "Delete From LE where NgayLe = '" + dateTimePicker1.Value + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Không xóa");
            }
            string sql1 = "Select NgayLe as 'Ngày lễ' from LE";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;

            cn.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView3.CurrentCell.RowIndex;
            dateTimePicker1.Text = Convert.ToDateTime(dataGridView3.Rows[t].Cells[0].Value.ToString()).ToShortDateString();
            cn.Open();
            string sql31 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',ThoiGianTruc as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý',Luong as 'Lương theo ca',LuongLe as 'Lương lễ' from LUONG where ThoiGianTruc ='" + dataGridView3.Rows[t].Cells[0].Value.ToString() + "'";
            SqlDataAdapter da31 = new SqlDataAdapter(sql31, cn);
            DataTable dt31 = new DataTable();
            da31.Fill(dt31);
            dataGridView1.DataSource = dt31;
            cn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && textBox3.Text != "")
            {
                if (MessageBox.Show("Bạn muốn nhập lương theo ca ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    cn.Open();
                    string Sql = "Insert into LUONGTHEOCA values('" + comboBox1.SelectedValue + "','" + textBox3.Text + "')";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();

                    string sql1 = "Select L.TenDangNhap as 'Mã nhân viên',N.HoTen as 'Họ tên',concat(L.Luong,N' đồng')  as 'Lương theo ca' from LUONGTHEOCA L, NHANVIEN N where L.TenDangNhap = N.TenDangNhap";
                    SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView2.DataSource = dt1;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Không nhập");
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn mã nhân viên hoặc chưa ghi số lương");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();

            if (MessageBox.Show("Bạn muốn xóa lương theo ca này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                string Sql = "Delete From LUONGTHEOCA where TenDangNhap = '" + comboBox1.SelectedValue +"'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Không xóa");
            }
            string sql1 = "Select L.TenDangNhap as 'Mã nhân viên',N.HoTen as 'Họ tên',concat(L.Luong,N' đồng')  as 'Lương theo ca' from LUONGTHEOCA L, NHANVIEN N where L.TenDangNhap = N.TenDangNhap";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            cn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView2.CurrentCell.RowIndex;
            comboBox1.Text = (string)dataGridView2.Rows[t].Cells[0].Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string sql3 = "select C.TenDangNhap as 'Mã nhân viên',C.HoTen as 'Họ tên',C.ThoiGianTruc as 'Thời gian trực',C.CaTruc as 'Ca trực',C.QuanLy as 'Quản lý',L.Luong as 'Lương theo ca' from CATRUC C,LUONGTHEOCA L where L.TenDangNhap = C.TenDangNhap and C.TenDangNhap ='"+comboBox1.SelectedValue+"'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView4.DataSource = dt3;
            cn.Close();

            cn.Open();
            string sql31 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',ThoiGianTruc as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý',Luong as 'Lương theo ca',LuongLe as 'Lương lễ' from LUONG where TenDangNhap ='" + comboBox1.SelectedValue + "'";
            SqlDataAdapter da31 = new SqlDataAdapter(sql31, cn);
            DataTable dt31 = new DataTable();
            da31.Fill(dt31);
            dataGridView1.DataSource = dt31;
            cn.Close();
            cn.Open();
            bb = 0;
            gg = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ee = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                bb = bb + ee;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                kk = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                gg = gg + kk;
            }
            label5.Text = (gg+ee).ToString();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
 
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn tăng lương lễ này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                       for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                       {
                               h = Convert.ToInt32(textBox2.Text);
                               k = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value) * h / 100 - Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                               cn.Open();
                               string Sql = "update LUONG set LuongLe = " +Convert.ToInt64(k)+ " where ThoiGianTruc ='" + Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString() + "'";
                               SqlCommand cmd = new SqlCommand(Sql, cn);
                               cmd.ExecuteNonQuery();
                               cn.Close();

                               cn.Open();
                               string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',ThoiGianTruc as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý',Luong as 'Lương theo ca',LuongLe as 'Lương lễ' from LUONG where ThoiGianTruc ='" + Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString() + "'";
                               SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
                               DataTable dt3 = new DataTable();
                               da3.Fill(dt3);
                               dataGridView1.DataSource = dt3;
                               cn.Close();
                       }
            }
            else
            {
                MessageBox.Show("Không tăng");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView4.Rows.Count-1; i++)
            {
                cn.Open();
                string Sql = "Insert into LUONG values('" + (string)dataGridView4.Rows[i].Cells[0].Value + "',N'" + (string)dataGridView4.Rows[i].Cells[1].Value + "','" + Convert.ToDateTime(dataGridView4.Rows[i].Cells[2].Value).ToShortDateString() + "',N'" + (string)dataGridView4.Rows[i].Cells[3].Value + "','" + (string)dataGridView4.Rows[i].Cells[4].Value + "'," + Convert.ToInt64(dataGridView4.Rows[i].Cells[5].Value) + "," + s + ")";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xong");
                cn.Close();
            }
            cn.Open();
            string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',ThoiGianTruc as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý',Luong as 'Lương theo ca',LuongLe as 'Lương lễ' from LUONG where TenDangNhap ='" + comboBox1.SelectedValue + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
            cn.Close();
        }
        public int tt;
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (MessageBox.Show("Bạn muốn kết toán lương nhân viên này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                string Sql = "Delete From LUONG where TenDangNhap = '" + comboBox1.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Không kết toán");
            }
            string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',ThoiGianTruc as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý',Luong as 'Lương theo ca',LuongLe as 'Lương lễ' from LUONG where TenDangNhap ='" + comboBox1.SelectedValue + "'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
            cn.Close();
        }
    }
}
