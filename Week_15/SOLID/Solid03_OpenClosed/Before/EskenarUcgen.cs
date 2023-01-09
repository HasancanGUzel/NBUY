using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03_OpenClosed.Before
{
    public class EskenarUcgen
    {
        public int Kenar { get; set; }
        public int Yukseklik { get; set; }

        public EskenarUcgen(int kenar, int yukseklik)
        {
            Kenar = kenar;
            Yukseklik = yukseklik;
        }

    }
}
