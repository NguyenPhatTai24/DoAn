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
    public partial class Quản_lý_ca_trực : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Quản_lý_ca_trực()
        {
            InitializeComponent();
        }
        public string TK001;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string sql12 = "select HoTen from NHANVIEN where TenDangNhap ='"+comboBox1.SelectedValue+"'";
            SqlDataAdapter da12 = new SqlDataAdapter(sql12, cn);
            DataTable dt12 = new DataTable();
            da12.Fill(dt12);
            dataGridView3.DataSource = dt12;
            textBox1.Text = (string)dataGridView3.Rows[0].Cells[0].Value;
            cn.Close();
        }

        private void Quản_lý_ca_trực_Load(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select TenDangNhap from NHANVIEN where TenDangNhap like 'NV%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenDangNhap";
            comboBox1.ValueMember = "TenDangNhap";
           // comboBox1.SelectedIndex = -1;
            
            label6.Text = TK001;

            string sql4 = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC";
            SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView1.DataSource = dt4;


            string sql41 = "select * from QUANLYCATRUC";
            SqlDataAdapter da41 = new SqlDataAdapter(sql41, cn);
            DataTable dt41 = new DataTable();
            da41.Fill(dt41);
            dataGridView5.DataSource = dt41;

            cn.Close();
            dataGridView1.RowHeadersVisible = false;
        }
        public int s;
        public string ca;
        private void btthem_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex > -1 && (checkBox1.Checked == true || checkBox2.Checked == true))
            {
                if (MessageBox.Show("Bạn muốn thêm ca trực ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    s = 100;
                    string sql4 = "select STT from BIEN1 order by STT desc";
                    SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    dataGridView4.DataSource = dt4;
                    s = int.Parse(dt4.Rows[0][0].ToString()) + 1 + s;

                    if (checkBox1.Checked == true && checkBox2.Checked == true)
                        ca = "Sáng và Chiều";
                    else if (checkBox1.Checked == true)
                        ca = "Sáng";
                    else if (checkBox2.Checked == true)
                        ca = "Chiều";
                    cn.Open();
                    string Sql = "Insert into QUANLYCATRUC values(" + s + ",N'" + dateTimePicker1.Value.DayOfWeek + "','" + comboBox1.SelectedValue + "',N'" + textBox1.Text + "',N'" + dateTimePicker1.Value + "',N'" + ca + "','" + label6.Text + "')";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();

                    string sql3 = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGridView1.DataSource = dt3;

                    string sql11 = "Delete from BIEN1";
                    SqlCommand cmd11 = new SqlCommand(sql11, cn);
                    cmd11.ExecuteNonQuery();

                    string Sql12 = "Insert into BIEN1 values(" + s + ")";
                    SqlCommand cmd12 = new SqlCommand(Sql12, cn);
                    cmd12.ExecuteNonQuery();

                    string sql41 = "select * from QUANLYCATRUC";
                    SqlDataAdapter da41 = new SqlDataAdapter(sql41, cn);
                    DataTable dt41 = new DataTable();
                    da41.Fill(dt41);
                    dataGridView5.DataSource = dt41;
                }
                else
                {
                    MessageBox.Show("Không thêm");
                }
            }
            else if (comboBox1.SelectedIndex <= -1 && (checkBox1.Checked == true || checkBox2.Checked == true))
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên");
            }
            else if (comboBox1.SelectedIndex > -1 && (checkBox1.Checked != true && checkBox2.Checked != true))
            {
                MessageBox.Show("Bạn chưa chọn ca trực");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên và ca trực");
            }
            cn.Close();
            cn.Open();
            string sql111 = "Delete from BIEN1";
            SqlCommand cmd111 = new SqlCommand(sql111, cn);
            cmd111.ExecuteNonQuery();

            string Sql122 = "Insert into BIEN1 values(" + s + ")";
            SqlCommand cmd122 = new SqlCommand(Sql122, cn);
            cmd122.ExecuteNonQuery();

            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql4 = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC";
            SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView1.DataSource = dt4;
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã nhân viên để xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xóa ca trực này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    cn.Open();
                    string Sql = "Delete From QUANLYCATRUC where STT like N'" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();


                    string sql4 = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC";
                    SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    dataGridView1.DataSource = dt4;

                    string sql111 = "Delete from BIEN1";
                    SqlCommand cmd111 = new SqlCommand(sql111, cn);
                    cmd111.ExecuteNonQuery();

                    string Sql122 = "Insert into BIEN1 values(" + s + ")";
                    SqlCommand cmd122 = new SqlCommand(Sql122, cn);
                    cmd122.ExecuteNonQuery();

                    string sql41 = "select * from QUANLYCATRUC";
                    SqlDataAdapter da41 = new SqlDataAdapter(sql41, cn);
                    DataTable dt41 = new DataTable();
                    da41.Fill(dt41);
                    dataGridView5.DataSource = dt41;

                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Không xóa");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa ca trực này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "Delete From QUANLYCATRUC";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();


                string sql4 = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC";
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dataGridView1.DataSource = dt4;

                string sql41 = "select * from QUANLYCATRUC";
                SqlDataAdapter da41 = new SqlDataAdapter(sql41, cn);
                DataTable dt41 = new DataTable();
                da41.Fill(dt41);
                dataGridView5.DataSource = dt41;
                cn.Close();
            }
            else
            {
                MessageBox.Show("Không xóa");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
                ca = "Sáng và Chiều";
            else if (checkBox1.Checked == true)
                ca = "Sáng";
            else if (checkBox2.Checked == true)
                ca = "Chiều";
            if (MessageBox.Show("Bạn muốn cập nhật lại ca trực này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "update QUANLYCATRUC set ThoiGianTruc = '" + dateTimePicker1.Value + "',CaTruc =N'" + ca + "' where TenDangNhap = '" + comboBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();



                string sql4 = "select Thu as 'Thứ',TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from QUANLYCATRUC";
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dataGridView1.DataSource = dt4;

                string sql111 = "Delete from BIEN1";
                SqlCommand cmd111 = new SqlCommand(sql111, cn);
                cmd111.ExecuteNonQuery();

                string Sql122 = "Insert into BIEN1 values(" + s + ")";
                SqlCommand cmd122 = new SqlCommand(Sql122, cn);
                cmd122.ExecuteNonQuery();

                string sql41 = "select * from QUANLYCATRUC";
                SqlDataAdapter da41 = new SqlDataAdapter(sql41, cn);
                DataTable dt41 = new DataTable();
                da41.Fill(dt41);
                dataGridView5.DataSource = dt41;

                cn.Close();
            }
            else
            {
                MessageBox.Show("Không cập nhật");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cn.Close();
            cn.Open();

            int t = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[t].Cells[4].Value.ToString() == "0")
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else if (dataGridView1.Rows[t].Cells[4].Value.ToString() == "Sáng")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }
            else if (dataGridView1.Rows[t].Cells[4].Value.ToString() == "Chiều")
            {
                checkBox2.Checked = true;
                checkBox1.Checked = false;
            }
            else if (dataGridView1.Rows[t].Cells[4].Value.ToString() == "Sáng và Chiều")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
            }
            textBox1.Text = dataGridView1.Rows[t].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[t].Cells[1].Value.ToString();
            textBox2.Text = dataGridView5.Rows[t].Cells[0].Value.ToString();
            dateTimePicker1.Text = Convert.ToDateTime(dataGridView5.Rows[t].Cells[4].Value.ToString()).ToShortDateString();
            cn.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
