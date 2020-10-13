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
            data.Add(new PoklZaznam(1, 1, new DateTime(2020, 10, 13), "Příjem z banky", 20000, 20000, ""));
            data.Add(new PoklZaznam(2, 2, new DateTime(2020, 10, 14), "Tenisové míče", -2356, data.Last().zustatek - 2356, "Dotace - MŠMT"));
            data.Add(new PoklZaznam(3, 3, new DateTime(2020, 10, 15), "Občerstvení", -538, data.Last().zustatek - 538, ""));
            data.Add(new PoklZaznam(4, 4, new DateTime(2020, 10, 16), "Pronájem kurtu", 350, data.Last().zustatek + 350, ""));

            data.Add(new PoklZaznam(5, 5, new DateTime(2020, 10, 17), "Registrace soutěží", 2500, data.Last().zustatek - 2500, ""));
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
            throw new NotImplementedException();
        }
    }
}