using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Dura_Flow_System
{
    public partial class bill : Form
    {
        
        public bill()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            
                

        }

        private void display_Click(object sender, EventArgs e)
        {
            /*
            //var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("", con);
            
            cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "spBill"
                cmd.Parameters.AddWithValue("@Price",dataGridView1.Rows(i).Cells(0).Value.ToString);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
            
        }
    }
}
