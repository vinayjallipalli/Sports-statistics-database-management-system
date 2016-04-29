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
    public partial class Form14 : Form
    {
        public Form14(string s12)
        {
            InitializeComponent();
            label2.Text = s12;
            textBox1.MaxLength = 10;
            textBox2.MaxLength = 10;
            textBox3.MaxLength = 20;
            textBox4.MaxLength = 20;
            Fillcombo();
        }
        void Fillcombo()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats ;";
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
            Form5 f5 = new Form5(label2.Text);
            f5.Show();
            this.Hide();
        }

        private void Form14_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "update project.cricket_stats set player_id='" + this.textBox1.Text + "',team_id='" + this.textBox2.Text + "',player_name='" + this.textBox3.Text + "',team_name='" + this.textBox4.Text + "',no_of_matches_played='" + this.textBox5.Text + "',no_of_wickets_taken='" + this.textBox6.Text + "',no_of_runs_scored='" + this.textBox7.Text + "',highest_score='" + this.textBox8.Text + "',avg_strikerate='" + this.textBox9.Text + "',no_of_catches= '" + this.textBox10.Text + "' where player_id='" + this.textBox1.Text + "';";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("Updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {

            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "insert into project.cricket_stats (player_id,team_id,player_name,team_name,no_of_matches_played,no_of_wickets_taken,no_of_runs_scored,highest_score,avg_strikerate,no_of_catches) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox10.Text + "');";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "delete from project.cricket_stats where player_id='" + this.textBox1.Text + "';";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats where player_name='" + comboBox1.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string pid = myreader2.GetString("player_id");
                    string tid = myreader2.GetString("team_id");
                    string sName = myreader2.GetString("player_name");
                    string tname = myreader2.GetString("team_name");
                    string nmp = myreader2.GetString("no_of_matches_played");
                    string ng = myreader2.GetString("no_of_wickets_taken");
                    string na = myreader2.GetString("no_of_runs_scored");
                    string nh = myreader2.GetString("highest_score");
                    string np = myreader2.GetDouble("avg_strikerate").ToString();
                    string ngr = myreader2.GetString("no_of_catches");

                    textBox1.Text = pid;
                    textBox2.Text = tid;
                    textBox3.Text = sName;
                    textBox4.Text = tname;
                    textBox5.Text = nmp;
                    textBox6.Text = ng;
                    textBox7.Text = na;
                    textBox8.Text = nh;
                    textBox9.Text = np;
                    textBox10.Text = ngr;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.cricket_stats where player_name='" + textBox11.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string pid = myreader2.GetString("player_id");
                    string tid = myreader2.GetString("team_id");
                    string sName = myreader2.GetString("player_name");
                    string tname = myreader2.GetString("team_name");
                    string nmp = myreader2.GetString("no_of_matches_played");
                    string ng = myreader2.GetString("no_of_wickets_taken");
                    string na = myreader2.GetString("no_of_runs_scored");
                    string nh = myreader2.GetString("highest_score");
                    string np = myreader2.GetString("avg_strikerate");
                    string ngr = myreader2.GetFloat("no_of_catches").ToString();

                    textBox1.Text = pid;
                    textBox2.Text = tid;
                    textBox3.Text = sName;
                    textBox4.Text = tname;
                    textBox5.Text = nmp;
                    textBox6.Text = ng;
                    textBox7.Text = na;
                    textBox8.Text = nh;
                    textBox9.Text = np;
                    textBox10.Text = ngr;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }
    }
}
