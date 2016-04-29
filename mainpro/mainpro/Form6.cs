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
    public partial class Form6 : Form
    {
        string genderr;
        public Form6(string s3)
        {
            InitializeComponent();
            label12.Text = s3;
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
                while(myreader2.Read())
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        private void update_button_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "update project.player_table set player_name='" + this.textBox1.Text + "',player_id='" + this.textBox2.Text + "',sport_name='" + this.textBox3.Text + "',team_name='" + this.textBox4.Text + "',team_id='" + this.textBox5.Text + "',age='" + this.textBox6.Text + "',player_dob='" + this.dob.Text + "',nationality='" + this.textBox8.Text + "',player_gender='" + genderr + "',player_image= @IMG where player_id='" + this.textBox2.Text + "';";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                cmd2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
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
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length); 

            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "insert into project.player_table (player_name,player_id,sport_name,team_name,team_id,age,player_dob,nationality,player_gender,player_image) values ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.dob.Text + "','" + this.textBox8.Text +"','"+genderr+"',@IMG);";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                cmd2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("registered successfully");
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
            string query1 = "delete from project.player_table where player_id='" + this.textBox2.Text + "';";
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
        private void upload_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|ALL Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string picpath = openFileDialog1.FileName.ToString();
                textBox_image_path.Text = picpath;
                pictureBox1.ImageLocation = picpath;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.player_table where player_name='"+comboBox1.Text+"'"; ;
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
                    string tname= myreader2.GetString("team_name");
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
                    if(gendr=="m")
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked=false;
                    }
                    else if (gendr=="f")
                    {
                        radioButton1.Checked=false;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }

                    byte[] imgg = (byte[])(myreader2["player_image"]);
                    if(imgg==null)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            genderr = "m";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            genderr = "f";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(label12.Text);
            f5.Show();
            this.Hide();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            
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
    }
}
