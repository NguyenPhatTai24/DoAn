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
    public partial class Doanh_thu : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Doanh_thu()
        {
            InitializeComponent();
        }
        public string tkkk;
        private void Doanh_thu_Load(object sender, EventArgs e)
        {
            cn.Open();
            string sql16 = "select TenDangNhap from DANGNHAP where TenDangNhap like 'NV%'";
            SqlDataAdapter da16 = new SqlDataAdapter(sql16, cn);
            DataTable dt16 = new DataTable();
            da16.Fill(dt16);
            comboBox1.DataSource = dt16;
            comboBox1.DisplayMember = "TenDangNhap";
            comboBox1.ValueMember = "TenDangNhap";

            string sql101 = "select MaHD as 'Mã hóa đơn',TenDangNhap as 'Mã nhân viên',NgayXuat as 'Ngày xuất',TongTien as 'Tổng tiền' from HD";
            SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
            DataTable dt101 = new DataTable();
            da101.Fill(dt101);
            dataGridView1.DataSource = dt101;

            cn.Close();
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            label13.Text = tkkk;
        }
        public int kq;
        public int bien = 0;
        public int kq1;
        public int bien1 = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            cn.Close();
            cn.Open();
            bien = 0;
            kq = 0;
            string sql101 = "select MaHD as 'Mã hóa đơn',TenDangNhap as 'Mã nhân viên',NgayXuat as 'Ngày xuất',TongTien as 'Tổng tiền' from HD where TenDangNhap = '" +comboBox1.Text+ "'";
            SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
            DataTable dt101 = new DataTable();
            da101.Fill(dt101);
            dataGridView1.DataSource = dt101;           
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                bien = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                kq = kq + bien;
            }
            label6.Text = Convert.ToString(kq);
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bien1 = 0;
            kq1 = 0;
            int t = dataGridView1.CurrentCell.RowIndex;
            label8.Text = (string)dataGridView1.Rows[t].Cells[0].Value;
            cn.Open();
            string sql = "select MaHD as 'Mã hóa đơn', MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',SL as 'Số lượng',Gia as 'Giá' from CTHD where MaHD = '" + label8.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            cn.Close();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                bien1 = Convert.ToInt32(dataGridView2.Rows[i].Cells[7].Value);
                kq1 = kq1 + bien1;
            }
            label10.Text = Convert.ToString(kq1);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bien = 0;
            kq = 0;
            bien1 = 0;
            kq1 = 0;
            cn.Open();
            string sql101 = "select MaHD as 'Mã hóa đơn',TenDangNhap as 'Mã nhân viên',NgayXuat as 'Ngày xuất',TongTien as 'Tổng tiền' from HD";
            SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
            DataTable dt101 = new DataTable();
            da101.Fill(dt101);
            dataGridView1.DataSource = dt101;

            string sql = "select MaHD as 'Mã hóa đơn', MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',SL as 'Số lượng',Gia as 'Giá' from CTHD";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                bien = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                kq = kq + bien;
            }
            label6.Text = Convert.ToString(kq);

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                bien1 = Convert.ToInt32(dataGridView2.Rows[i].Cells[7].Value);
                kq1 = kq1 + bien1;
            }
            label10.Text = Convert.ToString(kq1);
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa hết ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "Delete From HD";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string Sql1 = "Delete From CTHD";
                SqlCommand cmd1 = new SqlCommand(Sql1, cn);
                cmd1.ExecuteNonQuery();
                cn.Close();

                string sql101 = "select * from HD";
                SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
                DataTable dt101 = new DataTable();
                da101.Fill(dt101);
                dataGridView1.DataSource = dt101;

                string sql = "select * from CTHD";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không xóa");
            }
        }
    }
}
