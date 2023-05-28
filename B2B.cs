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
    public partial class B2B : Form
    {
        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;



        public B2B()
        {
            InitializeComponent();
        }
        

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string ProductId = comboBox4.Text;
                string Date;
                string Description = textBox2.Text;
                string FromDate;
                string ToDate;


                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into BranchToBranch values (@ProductId,@Date,@Description,@FromDate,@ToDate)", con);

                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@FromDate", dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@ToDate", dateTimePicker3.Value.Date);

               



                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into BranchToBranch");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



        }

        private void clearFields()
        {
            comboBox4.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
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
            try
            {

                SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
                SqlCommand cmd = con.CreateCommand();




                db = new SqlDataAdapter("SELECT * FROM CompanyGoods", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox4.Items.Add(ROW["Id"].ToString());

                }
                DD.Text = DateTime.Now.ToString("dd-MM-yy");
            }



            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            DD.Text = DateTime.Now.ToString("dd-MM-yy");

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update BranchToBranch SET Date=@Date,Description=@Description,FromDate=@FromDate,ToDate=@ToDate where ProductId = @ProductId", con);

            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Description", textBox2.Text);
            cmd.Parameters.AddWithValue("@FromDate", dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@ToDate", dateTimePicker3.Value.Date);
            cmd.Parameters.AddWithValue("@ProductId", comboBox4.Text);

            cmd.ExecuteNonQuery();
            Show();
            clearFields();

            MessageBox.Show("Updated Successfully");
            Show();

        }






        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from BranchToBranch Where ProductId=@ProductId";
            cmd.Parameters.AddWithValue("@ProductId", comboBox4.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted");
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from BranchToBranch", con);
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
            cmd.CommandText = "select * from BranchToBranch where ProductID= '" + comboBox4.Text + "'";
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
            comboBox4.Text = row.Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            textBox2.Text = row.Cells[2].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT ID FROM CompanyGoods WHERE ID = '" + comboBox4.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
    }

