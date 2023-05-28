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
    public partial class salegoods : Form
    {

        int indexRow;
        int count;

        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;

        public salegoods()
        {
            InitializeComponent();
        }

        private void clearFields()
        {
            comboBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            text2.Text = " ";
            text5.Text = " ";
            text3.Text = " ";
            textBox1.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox9.Text = " ";
            textBox8.Text = " ";


        }

        private void Insert_Click(object sender, EventArgs e)
        {
           
            try
            {



                string VenderID = comboBox1.Text;
                string ProductID = textBox2.Text;
                string ProductName = textBox3.Text;
                string UnitPrice = text2.Text;
                string NoOfProducts = text5.Text;
                string TotalPrice = text3.Text;
                string Profit = textBox1.Text;
                string Discount = textBox4.Text;
                string BuyerName = textBox5.Text;
                string BuyerCNIC = textBox6.Text;
                string ShopName = textBox7.Text;
                string Contact = textBox8.Text;
                string Address = textBox9.Text;




                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Sales values (@VenderID,@ProductID,@ProductName,@UnitPrice,@NoOfProducts,@TotalPrice,@Profit,@Discount,@BuyerName,@BuyerCNIC,@ShopName,@Address,@Contact)", con);
                cmd.Parameters.AddWithValue("@VenderID", VenderID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                cmd.Parameters.AddWithValue("@NoOfProducts", NoOfProducts);
                cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                cmd.Parameters.AddWithValue("@Profit", Profit);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@BuyerName", BuyerName);
                cmd.Parameters.AddWithValue("@BuyerCNIC", BuyerCNIC);
                cmd.Parameters.AddWithValue("@ShopName", ShopName);
                cmd.Parameters.AddWithValue("@Contact", Contact);
                cmd.Parameters.AddWithValue("@Address", Address);
                
                

                cmd.ExecuteNonQuery();
                Show();
                clearFields();

                MessageBox.Show("Inserted into Sales");
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




                db = new SqlDataAdapter("SELECT * FROM Vendor", con);
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
            SqlCommand cmd = new SqlCommand("Update Sales SET VenderID=@VenderID,ProductName=@ProductName,UnitPrice=@UnitPrice,NoOfProducts=@NoOfProducts,TotalPrice=@TotalPrice,Profit=@Profit,Discount=@Discount,BuyerName=@BuyerName,BuyerCNIC=@BuyerCNIC,ShopName=@ShopName,Address=@Address,Contact=@Contact where ProductID=@ProductID", con);

            cmd.Parameters.AddWithValue("@VenderID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ProductID", textBox2.Text);
            cmd.Parameters.AddWithValue("@ProductName", textBox3.Text);
            cmd.Parameters.AddWithValue("@UnitPrice", text2.Text);
            cmd.Parameters.AddWithValue("@NoOfProducts", text5.Text);
            cmd.Parameters.AddWithValue("@TotalPrice", text3.Text);
            cmd.Parameters.AddWithValue("@Profit", textBox1.Text);
            cmd.Parameters.AddWithValue("@Discount", textBox4.Text);
            cmd.Parameters.AddWithValue("@BuyerName", textBox5.Text);
            cmd.Parameters.AddWithValue("@BuyerCNIC", textBox6.Text);
            cmd.Parameters.AddWithValue("@ShopName", textBox7.Text);
            cmd.Parameters.AddWithValue("@Address", textBox9.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox8.Text);

            cmd.ExecuteNonQuery();
            Show();
            clearFields();

            MessageBox.Show("Sales Updated Successfully");
            Show();

        }






        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Sales Where ProductID=@ProductID ";
            cmd.Parameters.AddWithValue("@ProductID", textBox2.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from Sales");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Sales", con);
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
            cmd.CommandText = "select * from Sales where ProductID= '" + textBox2.Text + "'";
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
            textBox2.Text = row.Cells[1].Value.ToString();
            //dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            textBox3.Text = row.Cells[2].Value.ToString();
            text2.Text = row.Cells[3].Value.ToString();
            text5.Text = row.Cells[4].Value.ToString();
            
            text3.Text = row.Cells[5].Value.ToString();
            textBox1.Text = row.Cells[6].Value.ToString();
            textBox4.Text = row.Cells[7].Value.ToString();
            textBox5.Text = row.Cells[8].Value.ToString();
            textBox6.Text = row.Cells[9].Value.ToString();
            textBox7.Text = row.Cells[10].Value.ToString();
            textBox9.Text = row.Cells[11].Value.ToString();
            textBox8.Text = row.Cells[12].Value.ToString();
            
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

        private void button4_Click(object sender, EventArgs e)
        {
            Vendor ven = new Vendor();
            ven.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{11}$");
            Regex r1 = new Regex(@"^[0-9]{13}$");
            if (r.IsMatch(textBox8.Text) && r1.IsMatch(textBox6.Text))
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

