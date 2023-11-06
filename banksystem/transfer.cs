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
    public partial class transfer : Form
    {
        public transfer()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server = LocalHost; database = pobank; username = root; password =; ");
        private void button1_Click(object sender, EventArgs e)
        {
            string fno, tono, date;
            double bal;

            fno = ftxt.Text;
            tono = totxt.Text;
            date = txtdate.Text;
            bal = double(txtamount.Text);

            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transation;

            transation = con.BeginTransaction();


            cmd.Connection = con;
            cmd.Transaction = transation;


            try
            {
                cmd.CommandText = "update account set balance = balance - ' " + bal + " ' where accid = ' " + fno + " ' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update account set balance = balance + ' " + bal + " ' where accid = ' " + tono + " ' ";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into transfer(     f_acc,to_acc,date,amount) values(' " + fno + " ',' " + tono + " ',' " + date + " ',' " + bal + "  ')";
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
