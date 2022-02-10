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
    public partial class Quản_lý_ngày_công : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Quản_lý_ngày_công()
        {
            InitializeComponent();
        }
        public string ql;
        private void Quản_lý_ngày_công_Load(object sender, EventArgs e)
        {
            label5.Text = ql;
            cn.Open();
            string sql = "select TenDangNhap from DANGNHAP where TenDangNhap like 'NV%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenDangNhap";
            comboBox1.ValueMember = "TenDangNhap";
            comboBox1.SelectedIndex = 0;

            
            comboBox1.SelectedIndex = -1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


            string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104) as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView2.DataSource = dt3;

            string sql10 = "select * from CATRUC";
            SqlDataAdapter da10 = new SqlDataAdapter(sql10, cn);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            dataGridView3.DataSource = dt10;
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
        }
        public int s;
        public string ca;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql10 = "select * from CATRUC where TenDangNhap ='"+comboBox1.SelectedValue+"'";
            SqlDataAdapter da10 = new SqlDataAdapter(sql10, cn);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            dataGridView3.DataSource = dt10;

            string sql1 = "select N.TenDangNhap as N'Mã nhân viên' , HoTen as N'Họ tên' from DANGNHAP D,NHANVIEN N where D.TenDangNhap = N.TenDangNhap and N.TenDangNhap = '" + comboBox1.SelectedValue + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;


            string sql = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC where TenDangNhap = '" + (string)dataGridView1.Rows[0].Cells[0].Value + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            cn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && (checkBox1.Checked == true || checkBox2.Checked == true))
            {
                s = 1;
                string sql4 = "select STT from BIEN order by STT desc";
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                s = int.Parse(dt4.Rows[0][0].ToString())+1;               
                cn.Open();
                if (checkBox1.Checked == true && checkBox2.Checked == true)
                    ca = "Sáng và Chiều";
                else if (checkBox1.Checked == true)
                    ca = "Sáng";
                else if (checkBox2.Checked == true)
                    ca = "Chiều";
                if (MessageBox.Show("Bạn muốn điểm danh ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    string Sql = "Insert into CATRUC values(" + s + ",'" + (string)dataGridView1.Rows[0].Cells[0].Value + "',N'" + (string)dataGridView1.Rows[0].Cells[1].Value + "',N'" + dateTimePicker1.Value + "',N'" + ca + "','" + label5.Text + "')";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();


                    string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGridView2.DataSource = dt3;

                    string sql14 = "select * from CATRUC";
                    SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
                    DataTable dt14 = new DataTable();
                    da14.Fill(dt14);
                    dataGridView3.DataSource = dt14;
                }
                else
                {
                    MessageBox.Show("Không điểm danh");
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

            string sql11 = "Delete from BIEN";
            SqlCommand cmd11 = new SqlCommand(sql11, cn);
            cmd11.ExecuteNonQuery();

            string Sql12 = "Insert into BIEN values(" + s + ")";
            SqlCommand cmd12 = new SqlCommand(Sql12, cn);
            cmd12.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView2.DataSource = dt3;

            string sql14 = "select * from CATRUC";
            SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
            DataTable dt14 = new DataTable();
            da14.Fill(dt14);
            dataGridView3.DataSource = dt14;

            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa danh sách này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string Sql = "Delete From CATRUC where TenDangNhap ='" + (string)dataGridView1.Rows[0].Cells[0].Value + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();
                }



                string sql4 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC";
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, cn);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dataGridView2.DataSource = dt4;
                cn.Close();
            }
            else
            {
                MessageBox.Show("Không xóa");
            }
        }
        
        public void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cn.Close();
            cn.Open();

            int t = dataGridView2.CurrentCell.RowIndex;
            label6.Text = dataGridView3.Rows[t].Cells[4].Value.ToString();
                if (label6.Text == "0")
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                }
                else if (label6.Text == "Sáng")
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                }
                else if (label6.Text == "Chiều")
                {
                    checkBox2.Checked = true;
                    checkBox1.Checked = false;
                }
                else if (label6.Text == "Sáng và Chiều")
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                }
            textBox1.Text = dataGridView3.Rows[t].Cells[0].Value.ToString();
            dateTimePicker1.Text = Convert.ToDateTime(dataGridView3.Rows[t].Cells[3].Value.ToString()).ToShortDateString();
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn để xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xóa danh sách này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    cn.Open();
                    string Sql = "Delete From CATRUC where STT like N'" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();


                    string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC";
                    SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGridView2.DataSource = dt3;
                    cn.Close();

                    string sql14 = "select * from CATRUC";
                    SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
                    DataTable dt14 = new DataTable();
                    da14.Fill(dt14);
                    dataGridView3.DataSource = dt14;
                }
                else
                {
                    MessageBox.Show("Không xóa");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
                ca = "Sáng và Chiều";
            else if (checkBox1.Checked == true)
                ca = "Sáng";
            else if (checkBox2.Checked == true)
                ca = "Chiều";

            if (MessageBox.Show("Bạn muốn cập nhật lại ngày công này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("xong");
                cn.Open();
                string Sql = "update CATRUC set ThoiGianTruc = '" + dateTimePicker1.Value + "',CaTruc =N'" + ca + "' where TenDangNhap = '" + comboBox1.Text + "' and STT = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string sql3 = "select TenDangNhap as 'Mã nhân viên',HoTen as 'Họ tên',CONVERT(VARCHAR(10), ThoiGianTruc, 104)as 'Thời gian trực',CaTruc as 'Ca trực',QuanLy as 'Quản lý' from CATRUC";
                SqlDataAdapter da3 = new SqlDataAdapter(sql3, cn);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dataGridView2.DataSource = dt3;

                string sql14 = "select * from CATRUC";
                SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
                DataTable dt14 = new DataTable();
                da14.Fill(dt14);
                dataGridView3.DataSource = dt14;
                cn.Close();
            }
            else
            {
                MessageBox.Show("Không cập nhật");
            }
        }

        public void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView2.CurrentCell.RowIndex;
            t = dataGridView3.CurrentCell.RowIndex;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
