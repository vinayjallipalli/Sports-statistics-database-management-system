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
    public partial class Form18 : Form
    {
        public Form18(String s1)
        {
            InitializeComponent();
            label2.Text = s1;
            loadtable2();
        }
        void loadtable2()
        {


            string myconnection = "datasource=localhost;port=3306;username=root;password=2938";
            MySqlConnection myconn = new MySqlConnection(myconnection);
            MySqlCommand cmd1 = new MySqlCommand("select * from project.fixtures;", myconn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(label2.Text);
            f5.Show();
            this.Hide();
        }

        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
