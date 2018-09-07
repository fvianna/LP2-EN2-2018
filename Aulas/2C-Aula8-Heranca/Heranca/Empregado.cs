using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Empregado : Funcionario
    {
        public int IdProjeto { get; set; }

        public Empregado(string n, string c, double s, int ip) : base(n, c, s)
        {
            Console.WriteLine("Construtor de Empregado");
            this.IdProjeto = ip;
        }
    }
            
}
