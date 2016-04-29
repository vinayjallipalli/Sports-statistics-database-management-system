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
    public partial class Form17 : Form
    {
        public Form17(String s1)
        {
            InitializeComponent();
            label2.Text = s1;
            
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(label2.Text);
            f8.Show();
            this.Hide();
        }
        void loadtable()
        {
            
            
            string myconnection = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn = new MySqlConnection(myconnection);
            MySqlCommand cmd1 = new MySqlCommand("call project.team('"+textBox1.Text+"');", myconn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd1;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();
                bs.DataSource = dbdataset;
                dataGridView1.DataSource = dbdataset;
                sda.Update(dbdataset);

                myconn.Open();
                MySqlDataReader myreader = cmd1.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadtable2()
        {


            string myconnection = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn = new MySqlConnection(myconnection);
            MySqlCommand cmd1 = new MySqlCommand("call project.fix('" + textBox1.Text + "');", myconn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd1;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bs = new BindingSource();
                bs.DataSource = dbdataset;
                dataGridView2.DataSource = dbdataset;
                sda.Update(dbdataset);

                myconn.Open();
                MySqlDataReader myreader = cmd1.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form17_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                loadtable();
                loadtable2();
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
