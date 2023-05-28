﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dura_Flow_System
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboard dm = new dashboard();
            dm.Show();

            this.Hide();
        }

        private void StockManage_Load(object sender, EventArgs e)
        {

        }

        private void stock_Click(object sender, EventArgs e)
        {
            loadform(new salegoods());
        }

        private void production_Click(object sender, EventArgs e)
        {
            loadform(new SaleReturn());
        }

        private void GRN_Click(object sender, EventArgs e)
        {
          
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            
        }

        private void materialReq_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new B2B());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadform(new bill());
        }
    }
}