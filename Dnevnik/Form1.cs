using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;


namespace Dnevnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Ulaz u = new Ulaz();
            u.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Unos u = new Unos();
            u.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pregled p = new Pregled();
            p.Show();
        }
    }
}
