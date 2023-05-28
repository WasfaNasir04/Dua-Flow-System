using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dura_Flow_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                button3.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                button4.BringToFront();
                textBox2.PasswordChar = '\0';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //animation.AnimateWindow(this.Handle,2000,animation.HOR_NEGATIVE);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter Username & Password !");
            }
            else if (textBox1.Text == "Admin" || textBox2.Text == "GID43")
            {
                MessageBox.Show("Successfully Login !");
                dashboard dd = new dashboard();
                dd.Show();

                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Credentials!!!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
