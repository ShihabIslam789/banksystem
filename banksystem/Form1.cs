using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banksystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txtuser.Text;
            password = txtpass.Text;

            count = count + 1;

            if(count > 3)
            {

                MessageBox.Show("System has been blocked!!!");
                Application.Exit();
            }

            if (username == " " && password == " ")
            {
                Label4.Text = "Blank not be allowed";
            }

            else if (username.Length >= 10 && password.Length >= 10)
            {
                Label4.Text = "Max of 10 characters";
            }
            else
            {


                if (username == "bov" && password == "432")
                {
                    //Label4.Text = "Login Successfully";
                    progbar pr = new progbar();
                    this.Hide();
                    pr.Show();
                }
                else
                {
                    Label4.Text = "Invalid username and Password";
                    txtuser.Clear();
                    txtpass.Clear();
                    txtuser.Focus();
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label4.Text = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
