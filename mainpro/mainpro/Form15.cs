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
    public partial class Form15 : Form
    {
        public Form15(string s16)
        {
            InitializeComponent();
            label2.Text = s16;
            Fillcombo();

        }
        void Fillcombo()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.player_table where sport_name='cricket'"; ;
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


        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(label2.Text);
            f8.Show();
            this.Hide();
        }

        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats,project.player_table where cricket_stats.player_name='" + textBox1.Text + "' and player_table.player_name='" + textBox1.Text + "'"; ;
            MySqlCommand cmd3 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd3.ExecuteReader();
                while (myreader2.Read())
                {
                    string tName = myreader2.GetString("team_name");
                    string matchesplayed = myreader2.GetInt32("no_of_matches_played").ToString();
                    string goals = myreader2.GetInt32("no_of_wickets_taken").ToString();
                    string assist = myreader2.GetInt32("no_of_runs_scored").ToString();
                    string hat = myreader2.GetInt32("highest_score").ToString();
                    string pen = myreader2.GetDouble("avg_strikerate").ToString();
                    string gratio = myreader2.GetInt32("no_of_catches").ToString();


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
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats,project.player_table where cricket_stats.player_name='" + textBox2.Text + "' and player_table.player_name='" + textBox2.Text + "'"; ;
            MySqlCommand cmd3 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd3.ExecuteReader();
                while (myreader2.Read())
                {
                    string tName = myreader2.GetString("team_name");
                    string matchesplayed = myreader2.GetInt32("no_of_matches_played").ToString();
                    string goals = myreader2.GetInt32("no_of_wickets_taken").ToString();
                    string assist = myreader2.GetInt32("no_of_runs_scored").ToString();
                    string hat = myreader2.GetInt32("highest_score").ToString();
                    string pen = myreader2.GetDouble("avg_strikerate").ToString();
                    string gratio = myreader2.GetInt32("no_of_catches").ToString();


                    label32.Text = tName;
                    label31.Text = matchesplayed;
                    label30.Text = goals;
                    label29.Text = assist;
                    label28.Text = hat;
                    label27.Text = pen;
                    label26.Text = gratio;


                    byte[] imgg = (byte[])(myreader2["player_image"]);
                    if (imgg == null)
                    {
                        pictureBox2 = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats,project.player_table where cricket_stats.player_name='" + comboBox1.Text + "' and player_table.player_name='" + comboBox1.Text + "'"; ;
            MySqlCommand cmd3 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd3.ExecuteReader();
                while (myreader2.Read())
                {
                    string tName = myreader2.GetString("team_name");
                    string matchesplayed = myreader2.GetInt32("no_of_matches_played").ToString();
                    string goals = myreader2.GetInt32("no_of_wickets_taken").ToString();
                    string assist = myreader2.GetInt32("no_of_runs_scored").ToString();
                    string hat = myreader2.GetInt32("highest_score").ToString();
                    string pen = myreader2.GetDouble("avg_strikerate").ToString();
                    string gratio = myreader2.GetInt32("no_of_catches").ToString();


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
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats,project.player_table where cricket_stats.player_name='" + comboBox2.Text + "' and player_table.player_name='" + comboBox2.Text + "'"; ;
            MySqlCommand cmd3 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd3.ExecuteReader();
                while (myreader2.Read())
                {
                    string tName = myreader2.GetString("team_name");
                    string matchesplayed = myreader2.GetInt32("no_of_matches_played").ToString();
                    string goals = myreader2.GetInt32("no_of_wickets_taken").ToString();
                    string assist = myreader2.GetInt32("no_of_runs_scored").ToString();
                    string hat = myreader2.GetInt32("highest_score").ToString();
                    string pen = myreader2.GetDouble("avg_strikerate").ToString();
                    string gratio = myreader2.GetInt32("no_of_catches").ToString();


                    label32.Text = tName;
                    label31.Text = matchesplayed;
                    label30.Text = goals;
                    label29.Text = assist;
                    label28.Text = hat;
                    label27.Text = pen;
                    label26.Text = gratio;


                    byte[] imgg = (byte[])(myreader2["player_image"]);
                    if (imgg == null)
                    {
                        pictureBox2 = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(imgg);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
