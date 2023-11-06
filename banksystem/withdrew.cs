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
    public partial class withdrew : Form
    {
        public withdrew()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server = LocalHost; database = pobank; username = root; password =; ");
        private void withdrew_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "Select * from account where accid = ' " + txtacc.Text + "'";
                MySqlCommand cmd = new MySqlCommand(str, con);

                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    txtbal.Text = rd[4].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string acno, date;
            double bal, withdraw;

            acno = txtacc.Text;
            date = txtdate.Text;
            bal = double.Parse(txtbal.Text);
            withdraw = double.Parse(txtwit.Text);

            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();


            cmd.Connection = con;
            cmd.Transaction = transation;


            try
            {
                cmd.CommandText = "update account set balance = balance - ' " + withdraw + " ' where accid = ' " + acno + " ' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into transaction(accid,date,bal,withdraw) values(' " + acno + " ',' " + date + " ',' " + bal + " ',' " + withdraw + "  ')";
                cmd.ExecuteNonQuery();

                transation.Commit();

                MessageBox.Show("transaction  sucess!");
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
    }
}
   
