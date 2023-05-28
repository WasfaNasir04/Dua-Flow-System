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
    public partial class PurchaseOrder: Form
    {
        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;

        public PurchaseOrder()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string OrderNo = textBox1.Text;
                string ItemName = comboBox4.Text;
                string ItemCode = comboBox1.Text;
                string Date;
                string Quantity = textBox6.Text;
                string SupplierId = comboBox3.Text;
                string PaymentMethod = comboBox2.Text;
                string Unit = textBox7.Text;
                





                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into PurchaseOrder values (@OrderNo,@ItemName,@ItemCode,@Date,@Quantity,@SupplierId,@PaymentMethod,@Unit)", con);

                cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@ItemCode", ItemCode);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                cmd.Parameters.AddWithValue("@PaymentMethod", PaymentMethod);
                cmd.Parameters.AddWithValue("@Unit", Unit);
                



                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into PurchaseOrder");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }




        }


        private void clearFields()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

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




                db = new SqlDataAdapter("SELECT * FROM Suppliers ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox3.Items.Add(ROW["SupplierId"].ToString());

                }
               



                    db = new SqlDataAdapter("SELECT * FROM RequiredItems ", con);
                    dt = new DataTable();
                    db.Fill(dt);
                    foreach (DataRow ROW in dt.Rows)
                    {
                        comboBox1.Items.Add(ROW["Code"].ToString());

                    }
                db = new SqlDataAdapter("SELECT * FROM RequiredItems ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox4.Items.Add(ROW["ItemName"].ToString());

                }
                DD.Text = DateTime.Now.ToString("dd-MM-yy");

            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            


            //DD.Text = DateTime.Now.ToString("dd-MM-yy");
            
        }

        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE PurchaseOrder SET ItemName=@ItemName,ItemCode=@ItemCode,Date=@Date,Quantity=@Quantity,SupplierId=@SupplierId,PaymentMethod=@PaymentMethod,Unit=@Unit WHERE OrderNo=@OrderNo", con);
            cmd.Parameters.AddWithValue("@ItemName", comboBox4.Text);
            cmd.Parameters.AddWithValue("@ItemCode", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@Quantity", textBox6.Text);
            cmd.Parameters.AddWithValue("@SupplierId", comboBox3.Text);
            cmd.Parameters.AddWithValue("@PaymentMethod", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Unit", textBox7.Text);
            cmd.Parameters.AddWithValue("@OrderNo", textBox1.Text);
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
            cmd.CommandText = "Delete from PurchaseOrder Where PurchaseOrderNo=@PurchaseOrderNo";
            cmd.Parameters.AddWithValue("@PurchaseOrderNo", textBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from PurchaseOrder");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from PurchaseOrder", con);
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
            cmd.CommandText = "select * from PurchaseOrder where OrderNo= '" + textBox1.Text + "'";
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
            comboBox4.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            textBox6.Text = row.Cells[4].Value.ToString();
            comboBox3.Text = row.Cells[5].Value.ToString();
            comboBox2.Text = row.Cells[6].Value.ToString();
            textBox7.Text = row.Cells[7].Value.ToString();
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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
            cmd = new SqlCommand("SELECT ItemName FROM RequiredItems WHERE ItemName = '" + comboBox4.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT Code FROM RequiredItems WHERE Code = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT SupplierId FROM Suppliers WHERE SupplierId = '" + comboBox3.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }

