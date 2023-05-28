using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dura_Flow_System
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();

            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            StockManage SM = new StockManage();
            SM.Show();

            this.Hide();
        }

        private void production_Click(object sender, EventArgs e)
        {
            ProductionDepart PD = new ProductionDepart();
            PD.Show();

            this.Hide();
        }

        private void Sales_Click(object sender, EventArgs e)
        {
            Sales sa = new Sales();
            sa.Show();

            this.Hide();
        }

        private void transport_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transport tt = new Transport();
            tt.Show();

            this.Hide();
        }

        private void gatepass_Click(object sender, EventArgs e)
        {
            Gatepass gg = new Gatepass();
            gg.Show();

            this.Hide();
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            staffManage st = new staffManage();
            st.Show();

            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Form1 W = new Form1();
            W.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reports rt = new reports();
            rt.Show();

            this.Hide();
        }
    }
}
