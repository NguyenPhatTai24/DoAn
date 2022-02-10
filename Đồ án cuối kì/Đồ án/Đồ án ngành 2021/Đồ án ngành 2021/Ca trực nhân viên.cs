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
    public partial class Ca_trực_nhân_viên : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Ca_trực_nhân_viên()
        {
            InitializeComponent();
        }
        public string TK221;
        private void Ca_trực_nhân_viên_Load(object sender, EventArgs e)
        {
            label3.Text = TK221;
            cn.Open();
            string sql = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC where TenDangNhap = '" + label3.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;
            cn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
