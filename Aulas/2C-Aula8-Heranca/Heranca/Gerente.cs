using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Gerente : Funcionario
    {
        public double Adicional { get; set; }

        public Gerente(string n, string c, double s, double adc) : base(n, c, s)
        {
            this.Adicional = adc;
        }

    }
}
