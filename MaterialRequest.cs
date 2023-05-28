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
   
    public partial class MaterialRequest: Form
    {

        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;

        public MaterialRequest()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string RequestNo = textBox1.Text;
                string ItemName = comboBox1.Text;
                string PurchaseOrderNo = comboBox2.Text;
                string Date;
                string RequestBy = textBox2.Text;
                string Quantity = textBox3.Text;
                string Description = textBox4.Text;
                string NeededDate;
                

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into MaterialRequisition values (@RequestNo,@ItemName,@PurchaseOrderNo,@Date,@RequestBy,@Quantity,@Description,@NeededDate)", con);

                cmd.Parameters.AddWithValue("@RequestNo", RequestNo);
                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@PurchaseOrderNo", PurchaseOrderNo);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@RequestBy", RequestBy);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@NeededDate", dateTimePicker2.Value.Date);
                


                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into MaterialRequistion");
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


            db = new SqlDataAdapter("SELECT * FROM PurchaseOrder ", con);
            dt = new DataTable();
            db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {

                    comboBox2.Items.Add(ROW["OrderNo"].ToString());

                    // DD.Text = DateTime.Now.ToString("dd-MM-yy");
                }
                db = new SqlDataAdapter("SELECT * FROM RequiredItems ", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {

                    comboBox1.Items.Add(ROW["ItemName"].ToString());

                     DD.Text = DateTime.Now.ToString("dd-MM-yy");
                }

            }
        


            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }
            private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update MaterialRequisition SET ItemName=@ItemName,PurchaseOrderNo=@PurchaseOrderNo,Date=@Date,RequestBy=@RequestBy,Quantity=@Quantity,Description=@Description,NeededDate=@NeededDate where RequestNo=@RequestNo", con);

            cmd.Parameters.AddWithValue("@ItemName", comboBox1.Text);
            cmd.Parameters.AddWithValue("@PurchaseOrderNo", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@RequestBy", textBox2.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@Description", textBox4.Text);
            cmd.Parameters.AddWithValue("@NeededDate", dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@RequestNo", textBox1.Text);
            

            cmd.ExecuteNonQuery();
            Show();
            clearFields();

            MessageBox.Show("Updated Successfully");
            Show();

        }



        private void clearFields()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker2.Text = "";

        }


        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from MaterialRequisition Where RequestNo=@RequestNo";
            cmd.Parameters.AddWithValue("@RequestNo", textBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted ");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from  MaterialRequisition", con);
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
            cmd.CommandText = "select * from MaterialRequisition where RequestNo= '" + textBox1.Text + "'";
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
            textBox3.Text = row.Cells[5].Value.ToString();
            textBox4.Text = row.Cells[6].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            dt = new DataTable();


            dr = null;
            cmd = new SqlCommand("SELECT OrderNo FROM PurchaseOrder WHERE OrderNo = '" + comboBox2.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
    }

