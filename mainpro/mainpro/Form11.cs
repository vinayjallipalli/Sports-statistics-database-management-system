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

using System.Web;
using System.Net.Mail;

namespace mainpro
{
    public partial class Form11 : Form
    {
        public Form11(string s4,string s6)
        {
            InitializeComponent();
            label7.Text = s4;            
            textBox5.Text = "smtp.gmail.com";
            textBox1.Text = s6;
            
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(label7.Text);
            f8.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                MailMessage mail = new MailMessage(textBox1.Text, "vinayjallipalli2@gmail.com", textBox6.Text, richTextBox1.Text);
                SmtpClient client = new SmtpClient(textBox5.Text);
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("vinayjallipalli@gmail.com", "abhinay0072013");
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("MAIL SENT", "SUCCESS", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
