using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid05_InterfaceSegregation.After
{
    public class ElektrikliOtomobil : IOtomobilOrtak, IElektrikliMotor
    {
        public string BataryaTipiniGetir()
        {
            throw new NotImplementedException();
        }

        public int KaoiSayisiniGetir()
        {
            throw new NotImplementedException();
        }

        public int UretimYiliGetir()
        {
            throw new NotImplementedException();
        }

        public decimal VoltajDegerinigetir()
        {
            throw new NotImplementedException();
        }
    }
}
