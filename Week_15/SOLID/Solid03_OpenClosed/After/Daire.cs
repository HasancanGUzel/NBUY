﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03_OpenClosed.After
{
    public class Daire : Sekil
    {
        public int YariCap { get; set; }

        public Daire(int yariCap)
        {
            YariCap = yariCap;
        }

        public override double AlanHesapla()
        {
            return Math.PI * Math.Pow(YariCap, 2);
        }
    }
}
