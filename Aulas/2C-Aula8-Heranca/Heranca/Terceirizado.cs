using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Terceirizado : Empregado
    {
        public string EmpresaMatriz { get; set; }

        public Terceirizado(string n, string c, double s, int ip, string em) : base(n, c, s, ip)
        {
            Console.WriteLine("Construtor de Terceirizado");
            this.EmpresaMatriz = em;
        }
    }
}
