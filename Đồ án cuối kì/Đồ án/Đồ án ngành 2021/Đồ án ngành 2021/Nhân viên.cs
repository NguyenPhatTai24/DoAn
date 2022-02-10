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
    public partial class Nhân_viên : Form
    {
        public string TK;
        public Nhân_viên()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Xem_ngày_công xnc = new Xem_ngày_công();
            xnc.TK1 = label2.Text;
            xnc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shop s = new Shop();
            s.tkq = label2.Text;
            s.ShowDialog();
        }

        private void Nhân_viên_Load(object sender, EventArgs e)
        {
            label2.Text = TK;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ca_trực_nhân_viên ctnv = new Ca_trực_nhân_viên();
            ctnv.TK221 = label2.Text;
            ctnv.ShowDialog();
        }
    }
}
