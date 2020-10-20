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
            jsonRepos.VytvorTestData();
            repositar = jsonRepos;

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
    }
}