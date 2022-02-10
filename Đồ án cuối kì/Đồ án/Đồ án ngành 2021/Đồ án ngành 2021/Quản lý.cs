using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_ngành_2021
{
    public partial class Quản_lý : Form
    {
        public Quản_lý()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quản_lý_tài_khoản qltk = new Quản_lý_tài_khoản();
            qltk.TK1 = label2.Text;
            qltk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Quản_lý_nhân_viên qlnv = new Quản_lý_nhân_viên();
            qlnv.qll = label2.Text;
            qlnv.ShowDialog();
        }

        private void Quản_lý_Load(object sender, EventArgs e)
        {
            label2.Text = TK;
        }
        public string TK;
        private void label3_Click(object sender, EventArgs e)
        {
            Đổi_mật_khẩu_quản_lý dmkql = new Đổi_mật_khẩu_quản_lý();
            dmkql.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Quản_lý_ngày_công qlnc = new Quản_lý_ngày_công();
            qlnc.ql = label2.Text;
            qlnc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Quản_lý_lương qll = new Quản_lý_lương();
            qll.tkkk = label2.Text;
            qll.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sản_phẩm sp = new Sản_phẩm();
            sp.tkk12 = label2.Text;
            sp.ShowDialog();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Quản_lý_ca_trực qlct = new Quản_lý_ca_trực();
            qlct.TK001 = label2.Text;
            qlct.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Doanh_thu dt = new Doanh_thu();
            dt.tkkk = label2.Text;
            dt.ShowDialog();
        }
    }
}
