using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokladna
{
    public interface IRepos
    {
        List<PoklZaznam> NactiVse();

        PoklZaznam NactiZaznam(int idPokladniZaznam);

        PoklZaznam VytvorZaznam(PoklZaznam pokladniZaznam);

        void UpravZaznam(PoklZaznam poklZaznam);

        void SmazZaznam(PoklZaznam poklZaznam);
    }
}