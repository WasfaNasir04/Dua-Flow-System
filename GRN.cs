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
    public partial class GRN: Form
    {

        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;


        public GRN()
        {
            InitializeComponent();
        }
        private void clearFields()
        {
            text3.Text = "";
            comboBox1.Text = "";
            text5.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string GRN_No = text3.Text;
                string Innvoice_No = text5.Text;
                string PurchaseOrderNo = comboBox1.Text;
                string SupplierId = comboBox2.Text;
                string ItemName = comboBox3.Text;

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into GoodReturnNote values (@GRN_No,@Innvoice_No,@PurchaseOrderNo,@SupplierId,@ItemName)", con);
                cmd.Parameters.AddWithValue("@GRN_No", GRN_No);
                cmd.Parameters.AddWithValue("@Innvoice_No", Innvoice_No);
                cmd.Parameters.AddWithValue("@PurchaseOrderNo", PurchaseOrderNo);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);

                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into GoodReturnNote");
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




                db = new SqlDataAdapter("SELECT * FROM Suppliers ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox2.Items.Add(ROW["SupplierId"].ToString());

                }




                db = new SqlDataAdapter("SELECT * FROM PurchaseOrder ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox1.Items.Add(ROW["OrderNo"].ToString());
                    

                }
                db = new SqlDataAdapter("SELECT * FROM RequiredItems ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    
                    comboBox3.Items.Add(ROW["ItemName"].ToString());

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
            SqlCommand cmd = new SqlCommand("UPDATE GoodReturnNote SET Innvoice_No=@Innvoice_No,PurcahseOrderNo=@PurcahseOrderNo,SupplierID=@SupplierID,ItemName=@ItemName WHERE GRN_No=@GRN_No", con);
            cmd.Parameters.AddWithValue("@Innvoice_No", text5.Text);
            cmd.Parameters.AddWithValue("@PurcahseOrderNo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@SupplierID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ItemName", comboBox3.Text);
            cmd.Parameters.AddWithValue("@GRN_No", text3.Text);
            
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
            cmd.CommandText = "Delete from GoodReturnNote Where GRN_No=@GRN_No";
            cmd.Parameters.AddWithValue("@GRN_No", text3.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from GRN");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from GoodReturnNote", con);
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
            cmd.CommandText = "select * from GoodReturnNote where GRN_No= '" + text3.Text + "'";
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
            text3.Text = row.Cells[0].Value.ToString();
            text5.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            comboBox2.Text = row.Cells[3].Value.ToString();
            comboBox3.Text = row.Cells[4].Value.ToString();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT ItemName FROM RequiredItems WHERE itemName = '" + comboBox3.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT SupplierId FROM Suppliers WHERE SupplierId = '" + comboBox2.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT OrderNo FROM PurchaseOrder WHERE OrderNo= '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
    }

