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
    public partial class Attendance : Form
    {
        int indexRow;
        int count;

        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;


        public Attendance()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string EmployeeID = comboBox1.Text;
                string EntryTime;
                string ExitTime; 

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Attendance values (@EmployeeID,@EntryTime,@ExitTime)", con);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    
                cmd.Parameters.AddWithValue("@EntryTime", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@ExitTime", dateTimePicker2.Value.Date);

                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into Attendance");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }





        }
        private void clearFields()
        {
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";


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




                db = new SqlDataAdapter("SELECT * FROM Employee E", con);
                dt = new DataTable();
                db.Fill(dt);
                foreach (DataRow ROW in dt.Rows)
                {
                    comboBox1.Items.Add(ROW["ID"].ToString());

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
            SqlCommand cmd = new SqlCommand("Update Attendance SET EntryTime=@EntryTime, ExitTime=@ExitTime where EmployeeID=@EmployeeID", con);

            cmd.Parameters.AddWithValue("@EmployeeID",comboBox1.Text);
            cmd.Parameters.AddWithValue("@EntryTime",dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@ExitTime",dateTimePicker2.Value.Date);
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
            cmd.CommandText = "Delete from Attendance Where EmployeeId=@EmployeeId";
            cmd.Parameters.AddWithValue("@EmployeeId", comboBox1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from Attendance");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Attendance", con);
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
            cmd.CommandText = "select * from Attendance where EmployeeID= '" + comboBox1.Text + "'";
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

            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
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
            cmd = new SqlCommand("SELECT E.ID FROM Employee E WHERE E.ID = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
    }

