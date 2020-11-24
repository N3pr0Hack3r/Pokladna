using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pokladna
{
    public partial class Form1 : Form
    {
        private List<PoklZaznam> pokladna;
        private IRepos repositar;
        private PoklZaznam vybranyZaz;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JsonRepos jsonRepos = new JsonRepos("data.json");
            SqlRepos sqlRepos = new SqlRepos();
            //  jsonRepos.VytvorTestData();
            repositar = sqlRepos;
            // repositar.NactiVse();
            //    repositar = jsonRepos;

            comboBox1Rok.SelectedIndex = comboBox1Rok.Items.IndexOf(DateTime.Now.Year.ToString());
            comboBox2Mesic.SelectedIndex = DateTime.Now.Month - 1;

            /*  pokladna = repositar.NactiVse();
              foreach (var item in pokladna)
              {
                  listView1.Items.Add(item.DoLvItem());
              }*/
        }

        private void nacti()
        {
            listView1.Items.Clear();
            if (comboBox1Rok.SelectedIndex >= 0 && comboBox2Mesic.SelectedIndex >= 0)
            {
                try
                {
                    pokladna = repositar.Nacti(int.Parse(comboBox1Rok.SelectedItem.ToString()), comboBox2Mesic.SelectedIndex + 1);
                }
                catch (Exception)
                {
                    throw;
                }

                foreach (var item in pokladna)
                {
                    listView1.Items.Add(item.DoLvItem());
                }
            }
        }

        private void comboBox1Rok_SelectedIndexChanged(object sender, EventArgs e)
        {
            nacti();
        }

        private void comboBox2Mesic_SelectedIndexChanged(object sender, EventArgs e)
        {
            nacti();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text != "";
        }

        private void ko()
        {
            if (textBox2.Text.Trim() != "" && numericUpDown1.Value != 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ko();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ko();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repositar.VytvorZaznam(new PoklZaznam(dateTimePicker1.Value, textBox2.Text.Trim(), (double)numericUpDown1.Value, textBox3.Text.Trim()));
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = 0;
            cislodokladu.Text = "";
            nacti();
            ko();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            upR();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ulozit
            vybranyZaz.datum = dateTimePicker1.Value;
            vybranyZaz.popis = popis.Text;
            vybranyZaz.castka = Convert.ToDouble(numericUpDown1);
            vybranyZaz.poznamka = poznamka.Text;
            repositar.UpravZaznam(vybranyZaz);
        }

        private void upR()
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                vybranyZaz = pokladna[listView1.SelectedIndices[0]];
                cislodokladu.Text = vybranyZaz.cislo.ToString();
                popis.Text = vybranyZaz.popis;
                numericUpDown1.Value = Convert.ToDecimal(vybranyZaz.castka);
                poznamka.Text = vybranyZaz.poznamka;
                dateTimePicker1.Value = vybranyZaz.datum;
            }
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dele();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                upR();
            }
        }

        private void dele()
        {
            int vyindex = listView1.SelectedIndices[0];
            vybranyZaz = pokladna[vyindex];
            repositar.SmazZaznam(vybranyZaz);
            nacti();
            // TesetujFormular();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetriditPokladnu();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetriditPokladnu();
        }

        private void SetriditPokladnu()
        {
            string[] sloupce = new string[] { "Datum", "Popis", "Castka" };
            string sloupec = sloupce[comboBox1.SelectedIndex];
            string smer = checkBox1.Checked ? "desc" : "asc";

            if (checkBox1.Checked)
            {
                if (comboBox1.SelectedIndex == 0)
                    pokladna.Sort((b, a) => b.datum.CompareTo(a.datum));
                else if (comboBox1.SelectedIndex == 2)
                    pokladna.Sort((b, a) => b.popis.CompareTo(a.popis));
                else if (comboBox1.SelectedIndex == 3)
                    pokladna.Sort((b, a) => b.castka.CompareTo(a.castka));
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                    pokladna.Sort((a, b) => a.datum.CompareTo(b.datum));
                else if (comboBox1.SelectedIndex == 2)
                    pokladna.Sort((a, b) => a.popis.CompareTo(b.popis));
                else if (comboBox1.SelectedIndex == 3)
                    pokladna.Sort((a, b) => a.castka.CompareTo(b.castka));
            }
        }
    }
}