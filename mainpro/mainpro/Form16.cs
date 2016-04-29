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
    public partial class Form16 : Form
    {
        public Form16(string S2)
        {
            InitializeComponent();
            label2.Text = S2;
            Fillcombo();
        }
        void Fillcombo()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.fixtures"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sName = myreader2.GetString("fix_id");
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void add_Click(object sender, EventArgs e)
        {         
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "insert into project.fixtures (fix_id,team1,team2,sport,location,date) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.dob.Text + "');";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();                
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("fixture created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "update project.fixtures set fix_id='" + this.textBox1.Text + "',team1='" + this.textBox2.Text + "',team2='" + this.textBox3.Text + "',sport='" + this.textBox4.Text + "',location='" + this.textBox5.Text + "',date='" + this.dob.Text + "'where fix_id='" + this.textBox1.Text + "';";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();                
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("fixture Updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "delete from project.fixtures where fix_id='" + this.textBox1.Text + "';";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("Deletion successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(label2.Text);
            f5.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.fixtures where fix_id='" + comboBox1.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sName = myreader2.GetString("fix_id");
                    string pid = myreader2.GetString("team1");
                    string sportname = myreader2.GetString("team2");
                    string tname = myreader2.GetString("sport");
                    string tid = myreader2.GetString("location");                    
                    

                    textBox1.Text = sName;
                    textBox2.Text = pid;
                    textBox3.Text = sportname;
                    textBox4.Text = tname;
                    textBox5.Text = tid;
                                                                               

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
