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
    public partial class Leave : Form
    {

        int indexRow;
        int count;
        DataTable dt;
        SqlDataAdapter db;
        SqlDataReader dr;

        public Leave()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string LeaveID = text2.Text;
                string EmployeeID = comboBox1.Text;
                string FromDate;
                string ToDate;
                string Type = comboBox2.Text;

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Leaves values (@LeaveID,@EmployeeID,@FromDate,@ToDate,@Type)", con);

                cmd.Parameters.AddWithValue("@LeaveID", LeaveID);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@FromDate", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@ToDate", dateTimePicker2.Value.Date);
                cmd.Parameters.AddWithValue("@Type", Type);



                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into Leaves");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }



        }


        private void clearFields()
        {
            text2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBox2.Text = "";

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
                    comboBox1.Items.Add(ROW["ID"].ToString());

                }

                //DD.Text = DateTime.Now.ToString("dd-MM-yy");

            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }




           
        private void Update_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update Leaves SET EmployeeID=@EmployeeID, FromDate=@FromDate, ToDate=@ToDate, Type=@Type where LeaveID = @LeaveID", con);

            cmd.Parameters.AddWithValue("@LeaveID", text2.Text);
            cmd.Parameters.AddWithValue("@EmployeeID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@FromDate", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@ToDate", dateTimePicker2.Value.Date);
            cmd.Parameters.AddWithValue("@Type", comboBox2.Text);

            cmd.ExecuteNonQuery();
            Show();
            clearFields();

            MessageBox.Show("Employee Updated Successfully");
            Show();

        }






        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Leaves Where LeaveId=@LeaveId";
            cmd.Parameters.AddWithValue("@LeaveId", text2.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted from Leave");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Leaves", con);
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
            cmd.CommandText = "select * from Leaves where LeaveID= '" + text2.Text + "'";
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
            comboBox1.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            comboBox2.Text = row.Cells[4].Value.ToString();
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
            cmd = new SqlCommand("SELECT E.ID FROM Employee E WHERE E.Type = 'Vendor' and E.ID = '" + comboBox1.Text + "'", con);
            dr = cmd.ExecuteReader();

            dr.Close();
        }
    }
}

