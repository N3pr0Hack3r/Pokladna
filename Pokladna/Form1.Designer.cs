namespace Pokladna
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cislodokladu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.popis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prijmy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vydaje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zustatek = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.poznamka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1Rok = new System.Windows.Forms.ComboBox();
            this.comboBox2Mesic = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Datum,
            this.cislodokladu,
            this.popis,
            this.prijmy,
            this.vydaje,
            this.zustatek,
            this.poznamka});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(696, 560);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            this.Datum.Width = 72;
            // 
            // cislodokladu
            // 
            this.cislodokladu.Text = "Číslo dokladu";
            this.cislodokladu.Width = 100;
            // 
            // popis
            // 
            this.popis.DisplayIndex = 6;
            this.popis.Text = "Popis";
            // 
            // prijmy
            // 
            this.prijmy.DisplayIndex = 2;
            this.prijmy.Text = "Příjmy";
            this.prijmy.Width = 112;
            // 
            // vydaje
            // 
            this.vydaje.DisplayIndex = 3;
            this.vydaje.Text = "Výdaje";
            this.vydaje.Width = 96;
            // 
            // zustatek
            // 
            this.zustatek.DisplayIndex = 4;
            this.zustatek.Text = "Zůstatek";
            this.zustatek.Width = 112;
            // 
            // poznamka
            // 
            this.poznamka.DisplayIndex = 5;
            this.poznamka.Text = "Poznámka";
            this.poznamka.Width = 88;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(696, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 560);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2Mesic);
            this.groupBox1.Controls.Add(this.comboBox1Rok);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Učetní období";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Měsíc";
            // 
            // comboBox1Rok
            // 
            this.comboBox1Rok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1Rok.FormattingEnabled = true;
            this.comboBox1Rok.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021"});
            this.comboBox1Rok.Location = new System.Drawing.Point(60, 17);
            this.comboBox1Rok.Name = "comboBox1Rok";
            this.comboBox1Rok.Size = new System.Drawing.Size(121, 21);
            this.comboBox1Rok.TabIndex = 2;
            this.comboBox1Rok.SelectedIndexChanged += new System.EventHandler(this.comboBox1Rok_SelectedIndexChanged);
            // 
            // comboBox2Mesic
            // 
            this.comboBox2Mesic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2Mesic.FormattingEnabled = true;
            this.comboBox2Mesic.Items.AddRange(new object[] {
            "Leden",
            "Únor",
            "Březen",
            "Duben",
            "Květen",
            "Červen",
            "Červenec",
            "Srpen",
            "Září",
            "Říjen",
            "Listopad",
            "Prosinec"});
            this.comboBox2Mesic.Location = new System.Drawing.Point(60, 44);
            this.comboBox2Mesic.Name = "comboBox2Mesic";
            this.comboBox2Mesic.Size = new System.Drawing.Size(121, 21);
            this.comboBox2Mesic.TabIndex = 3;
            this.comboBox2Mesic.SelectedIndexChanged += new System.EventHandler(this.comboBox2Mesic_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 560);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader cislodokladu;
        private System.Windows.Forms.ColumnHeader prijmy;
        private System.Windows.Forms.ColumnHeader vydaje;
        private System.Windows.Forms.ColumnHeader zustatek;
        private System.Windows.Forms.ColumnHeader poznamka;
        private System.Windows.Forms.ColumnHeader popis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox2Mesic;
        private System.Windows.Forms.ComboBox comboBox1Rok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

