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
    public partial class Ven : Form
    {
        int indexRow;

        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;

        public Ven()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
                SqlCommand cmd = con.CreateCommand();




                db = new SqlDataAdapter("SELECT * FROM Employee E WHERE E.Type = 'Vendor' ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox1.Items.Add(ROW["ID"].ToString());

                }


                DD.Text = DateTime.Now.ToString("dd-MM-yy");


            }



            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }


        }

        private void display_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void show_Click(object sender, EventArgs e)
        {
            try
            {
                
                string EmployeeID = comboBox1.Text;




                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Vendor values(@EmployeeID)", con);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into Employee");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT E.ID FROM Employee E WHERE E.Type = 'Vendor' and E.ID = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Vendor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
