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
    public partial class Supplier : Form
    {


        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;
        public Supplier()
        {
            InitializeComponent();
        }
        private void clearFields()
        {
            text2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
            text3.Text = "";
            text5.Text = "";


        }
        private void Insert_Click(object sender, EventArgs e)
        {


            try
            {
                string SupplierID = text2.Text;
                string Name = text3.Text;
                string CNIC = text5.Text;
                string Contact = textBox1.Text;
                string Address = textBox3.Text;




                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Suppliers values (@SupplierID,@Name,@CNIC,@Contact,@Address)", con);

                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@CNIC", CNIC);

                cmd.Parameters.AddWithValue("@Contact", Contact);

                cmd.Parameters.AddWithValue("@Address", Address);


                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into Suppliers");
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
            DD.Text = DateTime.Now.ToString("dd-MM-yy");
        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Suppliers SET SupplierID=@SupplierID,CNIC=@CNIC,Contact=@Contact,Address=@Address WHERE Name=@Name", con);
            cmd.Parameters.AddWithValue("@SupplierID", text2.Text);
            cmd.Parameters.AddWithValue("@CNIC", text5.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox1.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@Name", text3.Text);

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
            cmd.CommandText = "Delete from Suppliers Where SupplierId=@SupplierId";
            cmd.Parameters.AddWithValue("@SupplierId", text2.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from Suppliers");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Suppliers", con);
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
            cmd.CommandText = "select * from Suppliers where SupplierID= '" + text2.Text + "'";
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
            text3.Text = row.Cells[1].Value.ToString();
            text5.Text = row.Cells[2].Value.ToString();
            textBox1.Text = row.Cells[3].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{11}$");
            Regex r1 = new Regex(@"^[0-9]{13}$");
            if (r.IsMatch(textBox1.Text) && r1.IsMatch(text5.Text))
            {
                //string Contact = textBox8.Text;
                //string[] row = new string[] { textBox1.Text };
                //dataGridView1.Rows.Add(row);
                //cmd.Parameters.AddWithValue("@Contact", Contact);
                MessageBox.Show("Valid Contact Number and CNIC");

            }
            else
            {
                MessageBox.Show("Invalid Contact Number or CNIC");
                //}
            }

        }
    }
}

