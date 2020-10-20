using System;
using System.Collections.Generic;

namespace Pokladna
{
    public class XmlRepos : IRepos
    {
        public List<PoklZaznam> Nacti(int rok, int mesic)
        {
            throw new NotImplementedException();
        }

        public List<PoklZaznam> NactiVse()
        {
            throw new NotImplementedException();
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