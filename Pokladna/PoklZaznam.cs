using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokladna
{
    public class PoklZaznam
    {
        public int idPoklZaznam { get; set; }
        public int cislo { get; set; }
        public DateTime datum { get; set; }
        public string popis { get; set; }
        public double castka { get; set; }
        public double zustatek { get; set; }
        public string poznamka { get; set; }

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
    }
}