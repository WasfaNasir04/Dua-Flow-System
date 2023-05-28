using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dura_Flow_System
{
    public partial class RequiredItems: Form
    {

        int indexRow;
        int count;
        public RequiredItems()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string Code = text2.Text;
                string ItemName = text5.Text;
                string ItemDescription = text3.Text;
                
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into RequiredItems values (@Code,@ItemDescription,@ItemName)", con);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@ItemDescription", ItemDescription);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                
                

                cmd.ExecuteNonQuery();
                Show();
                clearFields();
                MessageBox.Show("Inserted into RequiredItems");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



        }


        private void clearFields()
        {
            text2.Text = "";
            text3.Text = "";
            text5.Text = "";
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void text5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DD.Text = DateTime.Now.ToString("dd-MM-yy");

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE RequiredItems SET ItemDescription=@ItemDescription,ItemName=@ItemName WHERE Code=@Code", con);
            cmd.Parameters.AddWithValue("@Code", text2.Text);
            cmd.Parameters.AddWithValue("@ItemDescription", text5.Text);
            cmd.Parameters.AddWithValue("@ItemName", text3.Text);
            
            cmd.ExecuteNonQuery();
            Show();
            clearFields();
            MessageBox.Show("Successfully Updated");
            Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from RequiredItems Where Code=@Code";
            cmd.Parameters.AddWithValue("@Code", text2.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from RequiredItems");
            Show();
            clearFields();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from RequiredItems", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

            private void button2_Click(object sender, EventArgs e)
            {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            count = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from RequiredItems where Code= '" + text2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;

            if (count == 0)
            {
                MessageBox.Show("Record not found");
            }
            clearFields();
        }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];
            text2.Text = row.Cells[0].Value.ToString();
            text3.Text = row.Cells[2].Value.ToString();
            text5.Text = row.Cells[1].Value.ToString();
            
            }

            private void text3_TextChanged(object sender, EventArgs e)
            {

            }

            private void status_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

        private void Date_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
    }
    }

