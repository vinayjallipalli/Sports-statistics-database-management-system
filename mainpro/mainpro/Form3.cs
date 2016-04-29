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
    public partial class Form3 : Form
    {
        string genderr;
        public Form3()
        {
            InitializeComponent();
            name_t.MaxLength = 20;
            age_t.MaxLength = 3;
            username_t.MaxLength = 10;
            password_t.MaxLength = 10;
            contact_t.MaxLength = 10;
            address_t.MaxLength = 40;
            textBox1.MaxLength = 30;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {

            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);        
            
            string myconnection2 = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn2 = new MySqlConnection(myconnection2);
            string query1 = "insert into project.reg_table (name,age,dob,gender,username,password,contact_no,address,image,emailid) values ('"+this.name_t.Text+"','"+this.age_t.Text+"','"+this.dob.Text+"','"+genderr+"','"+this.username_t.Text+"','"+this.password_t.Text+"','"+this.contact_t.Text+"','"+this.address_t.Text+"',@IMG,'"+this.textBox1.Text+"');";
            MySqlCommand cmd2 = new MySqlCommand(query1, myconn2);
            try
            {
                myconn2.Open();
                cmd2.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                MySqlDataReader myreader2 = cmd2.ExecuteReader();
                MessageBox.Show("registered successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void name_t_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void age_t_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void username_t_TextChanged(object sender, EventArgs e)
        {
          
           
        }
     

        private void password_t_TextChanged(object sender, EventArgs e)
        {

        }

        private void contact_t_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void address_t_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            genderr = "m";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            genderr = "f";
        }

        private void dob_ValueChanged(object sender, EventArgs e)
        {

        }



        public MySqlDbType imageBt { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
