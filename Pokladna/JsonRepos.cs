using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pokladna
{
    public class JsonRepos : IRepos
    {
        private string datovySoubor;

        public JsonRepos(string soubor)
        {
            datovySoubor = soubor;
        }

        public void VytvorTestData()
        {
            List<PoklZaznam> data = new List<PoklZaznam>();
            data.Add(new PoklZaznam(1, 1, new DateTime(2020, 1, 13), "Příjem z banky", 20000, 20000, ""));
            data.Add(new PoklZaznam(2, 2, new DateTime(2020, 1, 14), "Tenisové míče", -2356, data.Last().zustatek - 2356, "Dotace - MŠMT"));
            data.Add(new PoklZaznam(3, 3, new DateTime(2020, 2, 15), "Občerstvení", -538, data.Last().zustatek - 538, ""));
            data.Add(new PoklZaznam(4, 4, new DateTime(2020, 3, 16), "Pronájem kurtu", 350, data.Last().zustatek + 350, ""));

            data.Add(new PoklZaznam(5, 5, new DateTime(2020, 4, 17), "Registrace soutěží", 2500, data.Last().zustatek - 2500, ""));
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(datovySoubor, json);
        }

        public List<PoklZaznam> NactiVse()
        {
            try
            {
                List<PoklZaznam> data = new List<PoklZaznam>();
                data = JsonConvert.DeserializeObject<List<PoklZaznam>>(File.ReadAllText(datovySoubor));
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PoklZaznam NactiZaznam(int idPokladniZaznam)
        {
            throw new NotImplementedException();
        }

        public void SmazZaznam(PoklZaznam poklZaznam)
        {
            throw new NotImplementedException();
        }

        public void UpravZaznam(PoklZaznam poklZaznam)
        {
            throw new NotImplementedException();
        }

        public PoklZaznam VytvorZaznam(PoklZaznam pokladniZaznam)
        {
            List<PoklZaznam> data = NactiVse();
            if (data.Find(doklad => doklad.datum > pokladniZaznam.datum) == null)
            //Novy zaznam je posledni
            {
                data.Sort((a, b) => a.idPoklZaznam.CompareTo(b.idPoklZaznam));
                pokladniZaznam.idPoklZaznam = data.Last().idPoklZaznam + 1;
                data.Sort((a, b) => a.datum.CompareTo(b.datum));
                pokladniZaznam.cislo = data.Last().datum.Month == pokladniZaznam.datum.Month ? data.Last().cislo + 1 : 1;
                pokladniZaznam.zustatek = data.Last().zustatek + pokladniZaznam.castka;
            }
            else
            {
                data.Sort((a, b) => a.idPoklZaznam.CompareTo(b.idPoklZaznam));
                pokladniZaznam.idPoklZaznam = data.Last().idPoklZaznam + 1;
                List<PoklZaznam> datames = data.FindAll(doklad => doklad.datum.Year == pokladniZaznam.datum.Year && doklad.datum.Month == pokladniZaznam.datum.Month);
                datames.Sort((a, b) => a.datum.CompareTo(b.datum));
                if (datames.Count > 0)
                {
                    if (datames.Find(doklad => doklad.datum > pokladniZaznam.datum) == null)
                    {
                        pokladniZaznam.cislo = datames.Last().cislo + 1;
                    }
                    else
                    {
                        int index = datames.FindIndex(doklad => doklad.datum > pokladniZaznam.datum);

                        pokladniZaznam.cislo = datames[index].cislo;
                        for (int i = index; i < datames.Count; i++)
                        {
                            datames[i].cislo += 1;
                        }
                    }
                }
                else
                {
                    pokladniZaznam.cislo = 1;
                }
            }
            data.Add(pokladniZaznam);
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(datovySoubor, json);
            return pokladniZaznam;
        }

        public List<PoklZaznam> Nacti(int rok, int mesic)
        {
            List<PoklZaznam> data = NactiVse();
            data = data.FindAll(prvek => prvek.datum.Year == rok && prvek.datum.Month == mesic);
            data.Sort((a, b) => a.datum.CompareTo(b.datum));
            return data;
        }
    }
}