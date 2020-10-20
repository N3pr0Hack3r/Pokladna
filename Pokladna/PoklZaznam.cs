using System;
using System.Windows.Forms;

namespace Pokladna
{
    public class PoklZaznam
    {
        public int idPoklZaznam { get; set; }
        public int cislo { get; set; }
        public DateTime datum { get; set; }
        public string popis { get; set; }
        public double castka { get; set; }
        public string poznamka { get; set; }
        public double zustatek { get; set; }

        public PoklZaznam(int idPoklZaznam, int cislo, DateTime datum, string popis, double castka, double zustatek, string poznamka)
        {
            this.idPoklZaznam = idPoklZaznam;
            this.cislo = cislo;
            this.datum = datum;
            this.popis = popis;
            this.castka = castka;
            this.zustatek = zustatek;
            this.poznamka = poznamka;
        }

        public PoklZaznam()
        {
        }

        public PoklZaznam(DateTime datum, string popis, double castka, string poznamka)
        {
            this.idPoklZaznam = -1;
            cislo = -1;
            zustatek = -1;
            this.datum = datum;
            this.popis = popis;
            this.castka = castka;
            this.poznamka = poznamka;
        }

        public ListViewItem DoLvItem()
        {
            if (castka > 0)
            {
                return new ListViewItem(new string[] { datum.ToString("dd.MM.yyyy"), cislo.ToString(), popis, Math.Abs(castka).ToString(), "", zustatek.ToString(), poznamka });
            }
            else
            {
                return new ListViewItem(new string[] { datum.ToString("dd.MM.yyyy"), cislo.ToString(), popis, "", Math.Abs(castka).ToString(), zustatek.ToString(), poznamka });
            }
        }
    }
}