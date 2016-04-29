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
    public partial class Form12 : Form
    {
        String genderr;
        public Form12(string s8)
        {
            InitializeComponent();
            label2.Text = s8;
            retrive();
        }
        void retrive()
        {
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "select * from project.reg_table where username='" + label2.Text + "'"; ;
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                while (myreader2.Read())
                {
                    string a1 = myreader2.GetString("name");
                    string age = myreader2.GetInt32("age").ToString();
                    string a2 = myreader2.GetDateTime("dob").ToString();
                    string gendr = myreader2.GetString("gender");
                    string a3 = myreader2.GetString("username");
                    string a4 = myreader2.GetString("password");
                    string a5= myreader2.GetString("contact_no");
                    string a6 = myreader2.GetString("address");
                    string a7 = myreader2.GetString("emailid");
                   


                    name_t.Text = a1;
                    age_t.Text = age;
                    dob.Text = a2;
                    username_t.Text = a3;
                    password_t.Text = a4;
                    contact_t.Text = a5;
                    address_t.Text = a6;
                    textBox1.Text = a7;
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

                    byte[] imgg = (byte[])(myreader2["image"]);
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
        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(label2.Text);
            f8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "update project.reg_table set name='" + this.name_t.Text + "',age='" + this.age_t.Text + "',dob='" + this.dob.Text + "',gender='" + genderr + "',username='" + this.username_t.Text + "',password='" + this.password_t.Text + "',contact_no='" + this.contact_t.Text + "',address='" + this.address_t.Text + "',image=@IMG,emailid='" + this.textBox1.Text + "' where username='"+label2.Text+"';";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                cmd2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|ALL Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string picpath = openFileDialog1.FileName.ToString();
                textBox_image_path.Text = picpath;
                pictureBox2.ImageLocation = picpath;

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
    }
}
