using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dura_Flow_System
{
    public partial class TransportManage: Form
    {
        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;



        public TransportManage()
        {
            InitializeComponent();
        }

        private void clearFields()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            text5.Text = "";
            text3.Text = "";
            comboBox4.Text = "";


        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string VehicleNo = comboBox1.Text;
                string DriverCNIC = textBox1.Text;
                string VehicleType = text5.Text;
                string DriverName = text3.Text;
                string ReturnID = comboBox4.Text;




                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Transport values (@VehicleNo,@DriverCNIC,@VehicleType,@DriverName,@ReturnID)", con);
                cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo);
                cmd.Parameters.AddWithValue("@DriverCNIC", DriverCNIC);
                cmd.Parameters.AddWithValue("@VehicleType", VehicleType);
                cmd.Parameters.AddWithValue("@DriverName", DriverName);
                cmd.Parameters.AddWithValue("@ReturnID", ReturnID);

                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into Transport");
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


                db = new SqlDataAdapter("SELECT * FROM SalesReturn ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {

                    comboBox1.Items.Add(ROW["VehicleNo"].ToString());

                    // DD.Text = DateTime.Now.ToString("dd-MM-yy");
                }
                db = new SqlDataAdapter("SELECT * FROM  SalesReturn ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {

                    comboBox4.Items.Add(ROW["ReturnID"].ToString());

                    DD.Text = DateTime.Now.ToString("dd-MM-yy");
                }

            }



            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            DD.Text = DateTime.Now.ToString("dd-MM-yy");
            DD.Text = DateTime.Now.ToString("dd-MM-yy");

        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Transport SET DriverCNIC=@DriverCNIC,VehicleType=@VehicleType,DriverName=@DriverName,ReturnID=@ReturnID WHERE VehicleNo=@VehicleNo", con);
            cmd.Parameters.AddWithValue("@DriverCNIC", textBox1.Text);
            cmd.Parameters.AddWithValue("@VehicleType", text5.Text);
            cmd.Parameters.AddWithValue("@DriverName", text3.Text);
            cmd.Parameters.AddWithValue("@ReturnID", comboBox4.Text);
            cmd.Parameters.AddWithValue("@VehicleNo", comboBox1.Text);
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
            cmd.CommandText = "Delete from Transport Where VehicleNo = @VehicleNo";
            cmd.Parameters.AddWithValue("@VehicleNo", comboBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted ");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Transport", con);
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
            cmd.CommandText = "select * from Transport where VehicleNo= '" + comboBox1.Text + "'";
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
            comboBox1.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            text5.Text = row.Cells[2].Value.ToString();
            text3.Text = row.Cells[3].Value.ToString();
            comboBox4.Text = row.Cells[4].Value.ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT VehicleNo FROM SalesReturn WHERE VehicleNo = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT ReturnID FROM SalesReturn WHERE ReturnID = '" + comboBox4.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{13}$");
            
            if (r.IsMatch(textBox1.Text))
            {
                //string Contact = textBox8.Text;
                //string[] row = new string[] { textBox1.Text };
                //dataGridView1.Rows.Add(row);
                //cmd.Parameters.AddWithValue("@Contact", Contact);
                MessageBox.Show("Valid CNIC");

            }
            else
            {
                MessageBox.Show("Invalid CNIC");
                //}
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

