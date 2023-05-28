using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dura_Flow_System
{
    public partial class GTReport : Form
    {
        public GTReport()
        {
            InitializeComponent();
        }

        private void GTReport_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from GatePass", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            crysGT GT = new crysGT();
            GT.Show();
            this.Hide();
        }
    }
}
