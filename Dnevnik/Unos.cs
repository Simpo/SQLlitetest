using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Dnevnik
{
    public partial class Unos : Form
    {
        public Unos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 3 || richTextBox1.Text.Length < 10 || comboBox1.Text.Length < 3)
                MessageBox.Show("Nije uneseno jedno od potrebnih polja", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                String naziv = textBox1.Text;
                String sadrzaj = richTextBox1.Text;
                String veza = comboBox1.Text;
                String datum = dateTimePicker1.Text;
                try
                {

                    SQLiteConnection thisConnection = new SQLiteConnection(@"Data Source=test");
                    thisConnection.Open();
                    SQLiteCommand komanda = new SQLiteCommand();
                    komanda.Connection = thisConnection;
                    komanda.CommandText = "insert into dnevnik (naziv,sadrzaj,datum,veza) values ('"+naziv+"','"+sadrzaj+"','"+datum+"','"+veza+"')";
                    komanda.ExecuteNonQuery();
                    MessageBox.Show("Uspješno dodano ", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception a)
                {
                    MessageBox.Show("Došlo je do greške: " + a.Message, "Greska", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //display any exeptions  

                }
                finally
                {
                    
                    //cn.Close();
                }  
                
            }
        }
    }
}
