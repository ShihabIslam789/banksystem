using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace banksystem
{
    public partial class Accountcreation : Form
    {
        public Accountcreation()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost; database = pobank; username = root; password=;");

        public void custid()
        {
            con.open();
            string query = "select max(custid) from customer ";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader dr;

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    label13.Text = "10000";

                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    label13.Text = a.ToString();
                }
                con.Close();
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Accountcreation_Load(object sender, EventArgs e)
        {
            custid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            button1.BackColor = ColorTranslator.FromHtml("#d90a0a");
            button2.BackColor = ColorTranslator.FromHtml("#d90a0a");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            button4.BackColor = ColorTranslator.FromHtml("#d90a0a");
            button3.BackColor = ColorTranslator.FromHtml("#d90a0a");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid, lname, fname, street, city, state, phone, date, email, acno, acctype, des, bal;

            cid = label14.Text;
            lname = txtlname.Text;
            fname = txtfname.Text;
            street = txtstreet.Text;
            city = txtcity.Text;
            state = txtstate.Text;
            phone = txtphone.Text;
            date = txtdate.Text;
            email = txtemail.Text;
            acno = txtacc.Text;
            acctype = txtacctype.Text;
            des = txtdesc.Text;
            bal = txtbal.Text;

            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();


            cmd.Connection = con;
            cmd.Transaction = transation;


            try
            {
                cmd.CommandText = "insertinfo customer(custid,lastname,firstname,street,city,state,phone,date,email) values('"+cid+" ',' "+lname+" ',' "+fname+" ',' " +street+" ',' "+city+" ',' "+state+" ','"+phone+"','"+date+" ',' "+email+" ' )" ;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into account(accid,custid,acctype,description,balance) values(' " + acno + " ',' " + cid + " ',' "+ acctype+" ',' " + des + " ',' " + bal + " ')";
                cmd.ExecuteNonQuery();

                transation.Commit();

                MessageBox.Show("Record added !");
            }

            catch (Exception ex)
            {
                transation.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
