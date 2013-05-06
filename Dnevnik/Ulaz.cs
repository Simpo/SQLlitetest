using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace Dnevnik
{
    public partial class Ulaz : Form
    {
        public Ulaz()
        {
            InitializeComponent();
        }

        private String dajhash(String unos)
        {
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(unos));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String sifra = textBox2.Text;
            sifra = dajhash(sifra);
            try
            {

                SQLiteConnection thisConnection = new SQLiteConnection(@"Data Source=test");
                thisConnection.Open();
                SQLiteCommand komanda = new SQLiteCommand();
                komanda.Connection = thisConnection;
                komanda.CommandText = "select * from ja";
                SQLiteDataReader citaj = komanda.ExecuteReader();
                while (citaj.Read())
                {
                    String s = citaj.GetString(0);
                    String u = citaj.GetString(1);
                    if (user == u && s == sifra)
                    {
                        Form1 f = new Form1();
                        f.Show();
                        this.Visible = false;
                    }
                    else
                        MessageBox.Show("Niste Nedim, zao mi je", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Došlo je do greške: " + a.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //display any exeptions  

            }
            finally
            {

                //cn.Close();
            }  
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
