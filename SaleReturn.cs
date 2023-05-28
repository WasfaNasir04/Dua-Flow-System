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
    public partial class SaleReturn : Form
    {

        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;

        public SaleReturn()
        {
            InitializeComponent();
        }

        private void clearFields()
        {
            text2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            text3.Text = "";
            text5.Text = "";

        }


        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string ReturnID = text2.Text;
                string Date;
                string Reason = textBox2.Text;                               
                string BuyerCompanyName = text5.Text;
                string BuyerName = text3.Text;
                string VenderID = comboBox1.Text;
                string DriverName = textBox5.Text;
                string VehicleNo = textBox3.Text;
                string ProductID = comboBox2.Text;
                string ReturnAmount = textBox4.Text;
                

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into SalesReturn values (@ReturnID,@Date,@Reason,@BuyerCompanyName,@BuyerName,@VenderID,@DriverName,@VehicleNo,@ProductID,@ReturnAmount)", con);
                cmd.Parameters.AddWithValue("@ReturnID", ReturnID);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Reason", Reason);
                cmd.Parameters.AddWithValue("@BuyerCompanyName", BuyerCompanyName);
                cmd.Parameters.AddWithValue("@BuyerName", BuyerName);
                cmd.Parameters.AddWithValue("@VenderID", VenderID);
                cmd.Parameters.AddWithValue("@DriverName", DriverName);
                cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ReturnAmount", ReturnAmount);
                
                cmd.ExecuteNonQuery();
                Show();
                clearFields();

                MessageBox.Show("Inserted into SalesReturn");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



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


                db = new SqlDataAdapter("SELECT * FROM Sales ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {

                    comboBox2.Items.Add(ROW["ProductID"].ToString());

                    // DD.Text = DateTime.Now.ToString("dd-MM-yy");
                }
                db = new SqlDataAdapter("SELECT * FROM Vendor ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {

                    comboBox1.Items.Add(ROW["EmployeeID"].ToString());

                   
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
            SqlCommand cmd = new SqlCommand("Update SalesReturn SET Date=@Date,Reason=@Reason,BuyerCompanyName=@BuyerCompanyName,BuyerName=@BuyerName,VenderID=@VenderID,DriverName=@DriverName,VehicleNo=@VehicleNo,ProductID=@ProductID,ReturnAmount=@ReturnAmount where ReturnID=@ReturnID", con);

            cmd.Parameters.AddWithValue("@ReturnID", text2.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Reason", textBox2.Text);
            cmd.Parameters.AddWithValue("@BuyerCompanyName", text5.Text);
            cmd.Parameters.AddWithValue("@BuyerName", text3.Text);
            cmd.Parameters.AddWithValue("@DriverName", textBox5.Text);
            cmd.Parameters.AddWithValue("@VenderID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VehicleNo", textBox3.Text);
            cmd.Parameters.AddWithValue("@ProductID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ReturnAmount", textBox4.Text);

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
            cmd.CommandText = "Delete from SalesReturn Where ReturnID=@ReturnID";
            cmd.Parameters.AddWithValue("@ReturnID", text2.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted ");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from SalesReturn", con);
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
            cmd.CommandText = "select * from SalesReturn where ReturnID= '" + text2.Text + "'";
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
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            textBox2.Text = row.Cells[2].Value.ToString();   
            text5.Text = row.Cells[3].Value.ToString();
            text3.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[5].Value.ToString();
            
            textBox5.Text = row.Cells[6].Value.ToString();
            textBox3.Text = row.Cells[7].Value.ToString();
            comboBox2.Text = row.Cells[8].Value.ToString();
            textBox4.Text = row.Cells[9].Value.ToString();
           
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT * From Sales WHERE ProductID = '" + comboBox2.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT * FROM Vendor WHERE EmployeeID = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
    }

