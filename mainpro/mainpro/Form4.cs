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

namespace mainpro
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 10;
            textBox2.MaxLength = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "datasource=localhost;port=3306;username=root;password=2938";
                MySqlConnection myconn = new MySqlConnection(myconnection);
                MySqlCommand cmd1 = new MySqlCommand("select * from project.admin_table where admin_id='" + this.textBox1.Text + "' and admin_password='" + this.textBox2.Text + "';", myconn);
                myconn.Open();
                MySqlDataReader myreader = cmd1.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    Form5 f5 = new Form5(textBox1.Text);
                    f5.Show();
                    this.Hide();
                }
                else if (count > 1)
                {
                    MessageBox.Show("duplicate username and password.....access denied");
                }
                else
                {
                    MessageBox.Show("username/password incorrect");
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
