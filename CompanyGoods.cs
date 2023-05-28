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
    public partial class CompanyGoods : Form
    {
        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;



        public CompanyGoods()
        {
            InitializeComponent();
        }
        private void clearFields()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox2.Text = "";
            text3.Text = "";
            text5.Text = "";
            text2.Text = "";

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = textBox1.Text;
                string RequestNo = comboBox1.Text;
                string VendorID = comboBox2.Text;
                string Date;

                string ProductName = textBox2.Text;
                string Description = text2.Text;
                string UnitPrice = text3.Text;
                string TotalProducts = text5.Text;





                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("Insert into CompanyGoods values(@ID,@RequestNo,@VendorID ,@Date,@ProductName,@Description,@UnitPrice,@TotalProducts)", con);

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@RequestNo", RequestNo);
                cmd.Parameters.AddWithValue("@VendorID", VendorID);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);

                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
                cmd.Parameters.AddWithValue("@TotalProducts", TotalProducts);



                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into CompanyGood");
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




                db = new SqlDataAdapter("SELECT * FROM Employee E WHERE E.Type = 'Vendor' ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox2.Items.Add(ROW["ID"].ToString());

                }




                db = new SqlDataAdapter("SELECT * FROM MaterialRequisition ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox1.Items.Add(ROW["RequestNo"].ToString());

                }

                DD.Text = DateTime.Now.ToString("dd-MM-yy");


            }



            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

private void Update_Click(object sender, EventArgs e)
        {

            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update CompanyGoods SET RequestNo=@RequestNo,VendorID=@VendorID ,Date=@Date,ProductName=@ProductName,Description=@Description,UnitPrice=@UnitPrice,TotalProducts=@TotalProducts where ID = @ID", con);

            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@RequestNo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VendorID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@ProductName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Description", text2.Text);
            cmd.Parameters.AddWithValue("@UnitPrice", text3.Text);
            cmd.Parameters.AddWithValue("@TotalProducts", text5.Text);
            
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
            cmd.CommandText = "Delete from CompanyGoods Where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from CompanyGoods");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from CompanyGoods", con);
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
            cmd.CommandText = "select * from CompanyGoods where ID= '" + textBox1.Text + "'";
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
            textBox1.Text = row.Cells[0].Value.ToString();
            comboBox1.Text = row.Cells[1].Value.ToString();
            comboBox2.Text = row.Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            textBox2.Text = row.Cells[4].Value.ToString();
            text2.Text = row.Cells[5].Value.ToString();
            text3.Text = row.Cells[6].Value.ToString();
            text5.Text = row.Cells[7].Value.ToString();
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
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT RequestNo FROM MaterialRequisition WHERE RequestNo = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT E.ID FROM Employee E WHERE E.Type = 'Vendor' and E.ID = '" + comboBox2.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
    }

