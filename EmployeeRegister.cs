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
    public partial class EmployeeRegister : Form
    {

        int indexRow;
        int count;
        public EmployeeRegister()
        {
            InitializeComponent();
        }
       
        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = textBox1.Text;
                string FirstName= textBox2.Text;
                string LastName = textBox3.Text;
                string CNIC = textBox4.Text;
                string Gender =comboBox1.Text;
                string Address = textBox5.Text;
                string Contact = textBox6.Text;
                string DateOfBirth;
                string Age = textBox7.Text;
                string Type = comboBox2.Text;
                string Salary = textBox8.Text;
                string AccountNo = textBox9.Text;




                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Employee values (@Id,@FirstName,@LastName,@CNIC,@Gender,@Address,@Contact,@DateOfBirth,@Age,@Type,@Salary,@AccountNo)", con);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@CNIC", CNIC);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Contact", Contact);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Age", Age); 
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Salary", Salary);
                cmd.Parameters.AddWithValue("@AccountNo", AccountNo);
                

                cmd.ExecuteNonQuery();
                Show();
                MessageBox.Show("Inserted into Employee");
                Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Employee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void clearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker1.Text = "";
            textBox7.Text = "";
            comboBox2.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

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
                SqlCommand cmd = new SqlCommand("Update Employee SET FirstName = @FirstName ,LastName = @LastName ,CNIC = @CNIC ,Gender = @Gender ,Address = @Address ,Contact = @Contact ,DateOfBirth = @DateOfBirth ,Age = @Age ,Type = @Type ,Salary = @Salary ,AccountNo = @AccountNo where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
                cmd.Parameters.AddWithValue("@CNIC", textBox4.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox6.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Age", textBox7.Text);
                cmd.Parameters.AddWithValue("@Type", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Salary",textBox8.Text);
                cmd.Parameters.AddWithValue("@AccountNo",textBox9.Text);
                
                cmd.ExecuteNonQuery();
                Show();
                clearFields();

                MessageBox.Show("Employee Updated Successfully");
                Show();


            

        }






        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = CRUD_Operations.Configuration.getInstance().getConnection();

            SqlCommand cmd = new SqlCommand("Delete from Employee Where Id= @Id", con);
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);

            cmd.ExecuteNonQuery();

            clearFields();
            showButton_Click(sender, e);
            MessageBox.Show("Deleted from Employee");
            Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Employee", con);
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
            cmd.CommandText = "select * from Employee where ID= '" + textBox1.Text + "'";
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
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            comboBox1.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox6.Text = row.Cells[6].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            textBox7.Text = row.Cells[8].Value.ToString();
            comboBox2.Text = row.Cells[9].Value.ToString();
            textBox8.Text = row.Cells[10].Value.ToString();
            textBox9.Text = row.Cells[11].Value.ToString();
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{11}$");
            Regex r1 = new Regex(@"^[0-9]{13}$");
            if (r.IsMatch(textBox6.Text) && r1.IsMatch(textBox4.Text))
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

