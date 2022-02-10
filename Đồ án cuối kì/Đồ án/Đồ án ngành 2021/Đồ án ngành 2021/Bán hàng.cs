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
    public partial class Shop : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=ShopSQL;Integrated Security=True");
        public Shop()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {         
           
        }
        public string tkq;
        public int kq = 0;
        public int kq1 = 0;
        public int haizz;
        private void Shop_Load(object sender, EventArgs e)
        {
            chuchay.Text = "Hãy đi làm đúng giờ và làm việc chăm chỉ nha các nhân viên yêu quý , cuối tháng sẽ tổng kết tăng lương";
            chuchayshop.Text = "Chào mừng các bạn đã đến với FanRonaldo Shop";
            dataGridView2.RowHeadersVisible = false;
            label19.Text = tkq;
            pictureBox4.Image = Image.FromFile("D://Hình nhân sự//" + label29.Text + ".jpg");
            cn.Open();
            string sql = "select MaHD as 'Mã hóa đơn', MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',SL as 'Số lượng',Gia as 'Giá' from CTHD";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;            
            for(int i = 0;i<dataGridView1.Rows.Count -1;i++)
            {
                kq1 = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                kq = Convert.ToInt32(kq + kq1);
            }
            label25.Text = kq.ToString();
            dataGridView3.RowHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView4.RowHeadersVisible = false;
            dataGridView5.RowHeadersVisible = false;

            string sql10 = "select MaHD as 'Mã hóa đơn',TenDangNhap as 'Mã nhân viên',NgayXuat as 'Ngày xuất',TongTien as 'Tổng tiền' from HD";
            SqlDataAdapter da10 = new SqlDataAdapter(sql10, cn);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            dataGridView3.DataSource = dt10;
            haizz = dataGridView3.Rows.Count;
            label30.Text = Convert.ToString(haizz - 1);
            label34.Text = tkq;
            string sql101 = "select MaHD as 'Mã hóa đơn',TenDangNhap as 'Mã nhân viên',NgayXuat as 'Ngày xuất',TongTien as 'Tổng tiền' from HD where TenDangNhap = '"+label34.Text+"'";
            SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
            DataTable dt101 = new DataTable();
            da101.Fill(dt101);
            dataGridView4.DataSource = dt101;
            cn.Close();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private int i = 10;
        private int j = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            chuchay.Left += i;
            if (chuchay.Left >= 200 || chuchay.Left <= 0)
            {
                i = -i;
            }
            chuchayshop.Left += j;
            if (chuchayshop.Left >= 500 || chuchayshop.Left <= 0)
            {
                j = -j;
            }
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Quần Áo")
            {
                cn.Open();
                string sql16 = "select MaSP from SANPHAM where MaSP like 'AQ%'";
                SqlDataAdapter da16 = new SqlDataAdapter(sql16, cn);
                DataTable dt16 = new DataTable();
                da16.Fill(dt16);
                comboBox1.DataSource = dt16;
                comboBox1.DisplayMember = "MaSP";
                comboBox1.ValueMember = "MaSP";

                string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where MaSP like 'AQ%'";
                SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
                DataTable dt17 = new DataTable();
                da17.Fill(dt17);
                dataGridView2.DataSource = dt17;

                cn.Close();
            }
            else if (comboBox4.Text == "Giày")
            {
                cn.Open();
                string sql16 = "select MaSP from SANPHAM where MaSP like 'GG%'";
                SqlDataAdapter da16 = new SqlDataAdapter(sql16, cn);
                DataTable dt16 = new DataTable();
                da16.Fill(dt16);
                comboBox1.DataSource = dt16;
                comboBox1.DisplayMember = "MaSP";
                comboBox1.ValueMember = "MaSP";

                string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where MaSP like 'GG%'";
                SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
                DataTable dt17 = new DataTable();
                da17.Fill(dt17);
                dataGridView2.DataSource = dt17;

                cn.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Close();
            cn.Open();
            string sql17 = "select MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',Gia as 'Giá',TonKho as 'Tồn kho',TenDangNhap as 'Quản lý' from SANPHAM where MaSP = '"+comboBox1.Text+"'";
            SqlDataAdapter da17 = new SqlDataAdapter(sql17, cn);
            DataTable dt17 = new DataTable();
            da17.Fill(dt17);
            dataGridView2.DataSource = dt17;
            cn.Close();
        }
        public int bien;
        public int bien1;
        public int bien2;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            int t = dataGridView2.CurrentCell.RowIndex;

            
            textBox5.Text = (string)dataGridView2.Rows[t].Cells[0].Value;
            
            textBox6.Text = (string)dataGridView2.Rows[t].Cells[1].Value;
            textBox7.Text = (string)dataGridView2.Rows[t].Cells[2].Value;
            textBox9.Text = dataGridView2.Rows[t].Cells[3].Value.ToString();
            textBox8.Text = (string)dataGridView2.Rows[t].Cells[4].Value;
            textBox10.Text = dataGridView2.Rows[t].Cells[6].Value.ToString();

            bien = int.Parse(dataGridView2.Rows[t].Cells[5].Value.ToString());
            bien1 = int.Parse(textBox9.Text);
            bien2 = bien * bien1 / 100;
            

            label5.Text = Convert.ToString(bien - bien2);
            cn.Open();
            string sql14 = "select LEFT(MaSP,4) from SANPHAM where MaSP like '" + textBox5.Text + "%'";
            SqlDataAdapter da14 = new SqlDataAdapter(sql14, cn);
            DataTable dt14 = new DataTable();
            da14.Fill(dt14);
            cn.Close();
            pictureBox1.Image = Image.FromFile("D://Hình sản phẩm//" + dt14.Rows[0][0].ToString() + ".jpg");
            numericUpDown1.Maximum = Convert.ToInt32(textBox10.Text);
        }
        public int k;
        public int t;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int t = dataGridView2.CurrentCell.RowIndex;
            k = int.Parse(dataGridView2.Rows[t].Cells[5].Value.ToString());
            t = Convert.ToInt32(numericUpDown1.Value.ToString());
            label5.Text = Convert.ToInt32(k*t).ToString();
            numericUpDown1.Maximum = Convert.ToInt32(textBox10.Text);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
        public int sl = 0;
        public int sl2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox3.Image = imageList1.Images[sl];
            if (sl == imageList1.Images.Count-1)
            {
                sl = 0;
            }
            else
            {
                sl++;
            }
            pictureBox2.Image = imageList2.Images[sl2];
            if (sl2 == imageList2.Images.Count-1)
            {
                sl2 = 0;
            }
            else
            {
                sl2++;
            }
        }
        public string s = "HD";
        public int sls = 1;
        public int gan;
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Bạn chưa thêm hóa đơn!!");
            }
            else
            {
                if (numericUpDown1.Value != 0)
                {
                    if (MessageBox.Show("Bạn muốn thêm sản phẩm vào hóa đơn ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        kq = 0;
                        MessageBox.Show("Thêm thành công, vui lòng xong qua hóa đơn kiểm tra lại");
                        cn.Open();
                        string Sql = "Insert into CTHD values('" + s + sls + "','" + textBox5.Text + "',N'" + textBox6.Text + "',N'" + textBox7.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + numericUpDown1.Value + "','" + label5.Text + "')";
                        SqlCommand cmd = new SqlCommand(Sql, cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        cn.Open();
                        string sql = "select MaHD as 'Mã hóa đơn', MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',SL as 'Số lượng',Gia as 'Giá' from CTHD where MaHD = '" + textBox1.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            kq1 = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                            kq = Convert.ToInt32(kq + kq1);
                        }
                        label25.Text = kq.ToString();
                        cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thêm");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn số lượng!!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql1 = "select case len(MaHD)when 8 then RIGHT(MaHD,6) when 7 then RIGHT(MaHD,5) when 6 then RIGHT(MaHD,4) when 5 then RIGHT(MaHD,3) when 4 then RIGHT(MaHD,2) when 3 then RIGHT(MaHD,1) end from HD";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cn.Close();
            if (dt1.Rows.Count == 0)
            {
                sls = 1;
            }
            else
            {
                gan = int.Parse(dt1.Rows[0][0].ToString());
                sls = sls + gan;
            }
            textBox2.Text = s + sls.ToString();
            textBox1.Text = textBox2.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn in hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Đã IN mời lấy bản IN");
                cn.Open();
                string Sql = "Insert into HD values('"+textBox1.Text+"','"+label29.Text+"','" +dateTimePicker1.Value+ "','"+label25.Text+"')";
                SqlCommand cmd = new SqlCommand(Sql, cn);
                cmd.ExecuteNonQuery();

                string sql1 = "select MaHD as 'Mã hóa đơn', TenDangNhap as 'Mã nhân viên', NgayXuat as 'Ngày xuất' , TongTien as 'Tổng tiền' from HD";
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, cn);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView3.DataSource = dt1;
                haizz = dataGridView3.Rows.Count;
                label30.Text = Convert.ToString(haizz - 1);

                string sql101 = "select MaHD as 'Mã hóa đơn',TenDangNhap as 'Mã nhân viên',NgayXuat as 'Ngày xuất',TongTien as 'Tổng tiền' from HD where TenDangNhap = '" + label34.Text + "'";
                SqlDataAdapter da101 = new SqlDataAdapter(sql101, cn);
                DataTable dt101 = new DataTable();
                da101.Fill(dt101);
                dataGridView4.DataSource = dt101;

                for (int h = 0; h < dataGridView1.Rows.Count; h++)
                {
                    string Sql3 = "update SANPHAM set TonKho = TonKho - '" + Convert.ToInt32(dataGridView1.Rows[h].Cells[6].Value) + "' where TenDangNhap ='" + label29.Text + "' and MaSP= '" + (string)dataGridView1.Rows[h].Cells[1].Value + "'";
                    SqlCommand cmd3 = new SqlCommand(Sql3, cn);
                    cmd3.ExecuteNonQuery();
                }

                    cn.Close();

                dataGridView1.DataSource = null;
            }
            else
            {
                MessageBox.Show("Không IN");
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView4.CurrentCell.RowIndex;
            label35.Text = (string)dataGridView4.Rows[t].Cells[0].Value;
            cn.Open();            
            string sql = "select MaHD as 'Mã hóa đơn', MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',SL as 'Số lượng',Gia as 'Giá' from CTHD where MaHD = '"+label35.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn để xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xóa danh sách này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("xong");
                    cn.Open();
                    string Sql = "Delete From CTHD where MaSP = '" + textBox3.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, cn);
                    cmd.ExecuteNonQuery();

                    string sql = "select MaHD as 'Mã hóa đơn', MaSP as 'Mã sản phẩm',TenSP as 'Tên sản phẩm',NhanHieu as 'Nhãn hiệu',KhuyenMai as 'Khuyến mãi',KichCo as 'Kích cỡ',SL as 'Số lượng',Gia as 'Giá' from CTHD where MaHD = '" +textBox1.Text+ "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Không xóa");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int t = dataGridView1.CurrentCell.RowIndex;
            textBox3.Text = (string)dataGridView1.Rows[t].Cells[1].Value;
        }
    }
}
