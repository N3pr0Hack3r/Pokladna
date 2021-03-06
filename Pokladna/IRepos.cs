﻿using System.Collections.Generic;

namespace Pokladna
{
    public interface IRepos
    {
        List<PoklZaznam> NactiVse();

        List<PoklZaznam> Nacti(int rok, int mesic);

        PoklZaznam NactiZaznam(int idPokladniZaznam);

        PoklZaznam VytvorZaznam(PoklZaznam pokladniZaznam);

        void UpravZaznam(PoklZaznam poklZaznam);

        void SmazZaznam(PoklZaznam poklZaznam);
    }
}