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
    public partial class Form10 : Form
    {
        public Form10(string s7)
        {
            InitializeComponent();
            label2.Text = s7;
            Fillcombo();

        }
        void Fillcombo()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.player_table where sport_name='football'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string sName = myreader2.GetString("player_name");
                    comboBox1.Items.Add(sName);
                    comboBox2.Items.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(label2.Text);
            f8.Show();
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.football_stats,project.player_table where football_stats.player_name='" + textBox1.Text + "' and player_table.player_name='" + textBox1.Text + "'"; ;
            MySqlCommand cmd3 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd3.ExecuteReader();
                while (myreader2.Read())
                {
                    string tName = myreader2.GetString("team_name");
                    string matchesplayed = myreader2.GetInt32("no_of_matches_played").ToString();
                    string goals = myreader2.GetInt32("no_of_goals").ToString();
                    string assist = myreader2.GetInt32("no_of_assists").ToString();
                    string hat = myreader2.GetInt32("no_of_hatricks").ToString();
                    string pen = myreader2.GetInt32("no_of_penalities").ToString();
                    string gratio = myreader2.GetFloat("goal_ratio").ToString() ;


                    label25.Text = tName;
                    label24.Text = matchesplayed;
                    label23.Text = goals;
                    label22.Text = assist;
                    label21.Text = hat;
                    label20.Text = pen;
                    label19.Text = gratio;
                   

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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn3 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.football_stats,project.player_table where football_stats.player_name='" + textBox2.Text + "' and player_table.player_name='"+textBox2.Text+"'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn3);
            try
            {
                myconn3.Open();
                MySqlDataReader myreader3 = cmd2.ExecuteReader();
                while (myreader3.Read())
                {
                    string tName1 = myreader3.GetString("team_name");
                    string matchesplayed1 = myreader3.GetInt32("no_of_matches_played").ToString();
                    string goals1 = myreader3.GetInt32("no_of_goals").ToString();
                    string assist1 = myreader3.GetInt32("no_of_assists").ToString();
                    string hat1 = myreader3.GetInt32("no_of_hatricks").ToString();
                    string pen1 = myreader3.GetInt32("no_of_penalities").ToString();
                    string gratio1 = myreader3.GetFloat("goal_ratio").ToString();


                    label32.Text = tName1;
                    label31.Text = matchesplayed1;
                    label30.Text = goals1;
                    label29.Text = assist1;
                    label28.Text = hat1;
                    label27.Text = pen1;
                    label26.Text = gratio1;


                    byte[] imgg2 = (byte[])(myreader3["player_image"]);
                    if (imgg2 == null)
                    {
                        pictureBox2 = null;
                    }
                    else
                    {
                        MemoryStream mstream2 = new MemoryStream(imgg2);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.football_stats,project.player_table where football_stats.player_name='" +comboBox1.Text + "' and player_table.player_name='" +comboBox1.Text + "'"; ;
            MySqlCommand cmd3 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd3.ExecuteReader();
                while (myreader2.Read())
                {
                    string tName = myreader2.GetString("team_name");
                    string matchesplayed = myreader2.GetInt32("no_of_matches_played").ToString();
                    string goals = myreader2.GetInt32("no_of_goals").ToString();
                    string assist = myreader2.GetInt32("no_of_assists").ToString();
                    string hat = myreader2.GetInt32("no_of_hatricks").ToString();
                    string pen = myreader2.GetInt32("no_of_penalities").ToString();
                    string gratio = myreader2.GetFloat("goal_ratio").ToString();


                    label25.Text = tName;
                    label24.Text = matchesplayed;
                    label23.Text = goals;
                    label22.Text = assist;
                    label21.Text = hat;
                    label20.Text = pen;
                    label19.Text = gratio;


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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn3 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.football_stats,project.player_table where football_stats.player_name='" + comboBox2.Text + "' and player_table.player_name='" + comboBox2.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn3);
            try
            {
                myconn3.Open();
                MySqlDataReader myreader3 = cmd2.ExecuteReader();
                while (myreader3.Read())
                {
                    string tName1 = myreader3.GetString("team_name");
                    string matchesplayed1 = myreader3.GetInt32("no_of_matches_played").ToString();
                    string goals1 = myreader3.GetInt32("no_of_goals").ToString();
                    string assist1 = myreader3.GetInt32("no_of_assists").ToString();
                    string hat1 = myreader3.GetInt32("no_of_hatricks").ToString();
                    string pen1 = myreader3.GetInt32("no_of_penalities").ToString();
                    string gratio1 = myreader3.GetFloat("goal_ratio").ToString();


                    label32.Text = tName1;
                    label31.Text = matchesplayed1;
                    label30.Text = goals1;
                    label29.Text = assist1;
                    label28.Text = hat1;
                    label27.Text = pen1;
                    label26.Text = gratio1;


                    byte[] imgg2 = (byte[])(myreader3["player_image"]);
                    if (imgg2 == null)
                    {
                        pictureBox2 = null;
                    }
                    else
                    {
                        MemoryStream mstream2 = new MemoryStream(imgg2);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream2);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }
    }
}
