using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections;
using System.Text.RegularExpressions;

namespace Dnevnik
{
    public partial class Pregled : Form
    {
        ArrayList dnevnici;
        public Pregled()
        {
            InitializeComponent();
            dnevnici = new ArrayList();
        }

        private void Ucitaj()
        {
            listBox1.Items.Clear();
            dnevnici.Clear();
            try
            {

                SQLiteConnection thisConnection = new SQLiteConnection(@"Data Source=test");
                thisConnection.Open();
                SQLiteCommand komanda = new SQLiteCommand();
                komanda.Connection = thisConnection;
                komanda.CommandText = "select * from dnevnik order by id desc";
                SQLiteDataReader citaj = komanda.ExecuteReader();
                while (citaj.Read())
                {
                    String datum = citaj.GetString(0);
                    int id = citaj.GetInt32(1);
                    String naziv = citaj.GetString(2);
                    String sadrzaj = citaj.GetString(3);
                    String veza = citaj.GetString(4);
                    Dnevnik d = new Dnevnik(naziv, sadrzaj, veza, datum, id);
                    dnevnici.Add(d);
                    listBox1.Items.Add(naziv);
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

        private void Pregled_Load(object sender, EventArgs e)
        {
            Ucitaj();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String naziv = listBox1.SelectedItem.ToString();
            for (int i = 0; i < dnevnici.Count; i++)
            {
                Dnevnik d = (Dnevnik)dnevnici[i];
                if (d.dajnaziv() == naziv)
                {
                    textBox1.Text = d.dajnaziv();
                    richTextBox1.Text = d.dajsadrzaj();
                    dateTimePicker1.Text = d.dajdatum();
                    textBox2.Text = d.dajvezu();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pretraga = textBox3.Text;
            String kriterij = comboBox1.Text;
            int brojac = 0;
            if (pretraga == "" && kriterij == "Izaberi")
            {
                MessageBox.Show("Nisi unio text za pretragu ili tip pretrage", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                brojac++;
            }
            else if (pretraga != "" && kriterij != "Izaberi")
            {
                listBox1.Items.Clear();
                for (int i = 0; i < dnevnici.Count; i++)
                {
                    Dnevnik d = (Dnevnik)dnevnici[i];
                    if (kriterij == "Naziv")
                    {
                        if (Regex.IsMatch(d.dajnaziv(), pretraga, RegexOptions.IgnoreCase))
                        {
                            listBox1.Items.Add(d.dajnaziv());
                            brojac++;
                        }
                    }
                    else if (kriterij == "Sadrzaj")
                    {
                        if (Regex.IsMatch(d.dajsadrzaj(), pretraga, RegexOptions.IgnoreCase))
                        {
                            listBox1.Items.Add(d.dajnaziv());
                            brojac++;
                        }
                    }
                    else if (kriterij == "Veza")
                    {
                        if (d.dajvezu().Contains(pretraga))
                        {
                            listBox1.Items.Add(d.dajnaziv());
                            brojac++;
                        }
                    }
                }
            }
            else if (pretraga == "" && kriterij != "Izaberi")
            {
                listBox1.Items.Clear();
                for (int i = 0; i < dnevnici.Count; i++)
                {
                    Dnevnik d = (Dnevnik)dnevnici[i];
                    if (d.dajvezu() == kriterij)
                    {
                        listBox1.Items.Add(d.dajnaziv());
                        brojac++;
                    }
                }
            }
            if (brojac == 0)
                MessageBox.Show("Nema rezultata", "Izlaz", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ucitaj();
        }
    }
}
