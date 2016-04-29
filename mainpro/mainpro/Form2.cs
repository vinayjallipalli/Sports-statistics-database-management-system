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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox2.PasswordChar='*';
            textBox1.MaxLength = 10;
            textBox2.MaxLength = 10;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "datasource=localhost;port=3306;username=root;password=2938";
                MySqlConnection myconn = new MySqlConnection(myconnection);
                MySqlCommand cmd1=new MySqlCommand("select * from project.reg_table where username='"+this.textBox1.Text+"' and password='"+this.textBox2.Text+"';",myconn);
                myconn.Open();
                MySqlDataReader myreader = cmd1.ExecuteReader();
                int count = 0;
                while(myreader.Read())
                {
                    count = count + 1;
                }
                if(count==1)
                {
                    Form8 f8 = new Form8(textBox1.Text);
                    f8.Show();
                    this.Hide();
                }
                else if(count>1)
                {
                    MessageBox.Show("duplicate username and password.....access denied");
                }
                else
                {
                    MessageBox.Show("username/password incorrect");
                }
                myconn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
