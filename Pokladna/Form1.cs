using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pokladna
{
    public partial class Form1 : Form
    {
        private List<PoklZaznam> pokladna;
        private IRepos repositar;

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
            repositar.NactiVse();
            //    repositar = jsonRepos;

            comboBox1Rok.SelectedIndex = 1;
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
            nacti();
            ko();
        }
    }
}