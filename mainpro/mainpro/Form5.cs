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
    public partial class Form5 : Form
    {
        public Form5(string s1)
        {
            InitializeComponent();
            label2.Text = s1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(label2.Text);
            f6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(label2.Text);
            f7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are u sure to logout","Logout",MessageBoxButtons.YesNo);
            if(dialog== DialogResult.Yes )
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else if(dialog==DialogResult.No)
            {
               
            }
           
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0)
            {
                Form13 f13 = new Form13(label2.Text);
                f13.Show();
                this.Hide();
            }
            if (comboBox1.SelectedIndex==1)
            {
                Form14 f14 = new Form14(label2.Text);
                f14.Show();
                this.Hide();
            }
        }

        private void fixtures_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16(label2.Text);
            f16.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18(label2.Text);
            f18.Show();
            this.Hide();
        }
    }
}
