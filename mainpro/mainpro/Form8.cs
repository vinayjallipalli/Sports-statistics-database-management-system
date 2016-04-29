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
using System.IO;


namespace mainpro
{
    public partial class Form8 : Form
    {
        public Form8(string username)
        {
            InitializeComponent();
            label2.Text = username;
            getmailid();
        }
        string mid;
       void getmailid()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.reg_table where username='"+label2.Text+"'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                     mid = myreader2.GetString("emailid");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are u sure to logout", "Logout", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }
        private void player_info_button_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9(label2.Text);
            f9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11(label2.Text,mid);
            f11.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(label2.Text);
            f12.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Form10 f10 = new Form10(label2.Text);
                f10.Show();
                this.Hide();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Form15 f15 = new Form15(label2.Text);
                f15.Show();
                this.Hide();
            }
        }

        private void teamlist_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17(label2.Text);
            f17.Show();
            this.Hide();
        }
    }
}
