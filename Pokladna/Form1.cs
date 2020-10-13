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
            pokladna = repositar.NactiVse();

            foreach (var item in pokladna)
            {
                listView1.Items.Add(item.DoLvItem());
            }
        }
    }
}