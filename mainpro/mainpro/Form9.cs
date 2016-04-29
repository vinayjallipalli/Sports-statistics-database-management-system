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
    public partial class Form9 : Form
    {
        public Form9(string s2)
        {
            InitializeComponent();
            label12.Text = s2;
            Fillcombo();
            textBox1.MaxLength = 20;
            textBox2.MaxLength = 10;
            textBox3.MaxLength = 20;
            textBox4.MaxLength = 20;
            textBox5.MaxLength = 10;
            textBox6.MaxLength = 3;
            textBox8.MaxLength = 20;

        }
        void Fillcombo()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.player_table"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sName = myreader2.GetString("player_name");
                    comboBox1.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(label12.Text);
            f8.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.player_table where player_name='" + comboBox1.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sName = myreader2.GetString("player_name");
                    string pid = myreader2.GetString("player_id");
                    string sportname = myreader2.GetString("sport_name");
                    string tname = myreader2.GetString("team_name");
                    string tid = myreader2.GetString("team_id");
                    string age = myreader2.GetInt32("age").ToString();
                    string national = myreader2.GetString("nationality");
                    string gendr = myreader2.GetString("player_gender");


                    textBox1.Text = sName;
                    textBox2.Text = pid;
                    textBox3.Text = sportname;
                    textBox4.Text = tname;
                    textBox5.Text = tid;
                    textBox6.Text = age;
                    textBox8.Text = national;
                    if (gendr == "m")
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else if (gendr == "f")
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }

                    byte[] imgg = (byte[])(myreader2["player_image"]);
                    if (imgg == null)
                    {
                        pictureBox1 = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.player_table where player_name='" + textBox7.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sName = myreader2.GetString("player_name");
                    string pid = myreader2.GetString("player_id");
                    string sportname = myreader2.GetString("sport_name");
                    string tname = myreader2.GetString("team_name");
                    string tid = myreader2.GetString("team_id");
                    string age = myreader2.GetInt32("age").ToString();
                    string national = myreader2.GetString("nationality");
                    string gendr = myreader2.GetString("player_gender");


                    textBox1.Text = sName;
                    textBox2.Text = pid;
                    textBox3.Text = sportname;
                    textBox4.Text = tname;
                    textBox5.Text = tid;
                    textBox6.Text = age;
                    textBox8.Text = national;
                    if (gendr == "m")
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else if (gendr == "f")
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }

                    byte[] imgg = (byte[])(myreader2["player_image"]);
                    if (imgg == null)
                    {
                        pictureBox1 = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
