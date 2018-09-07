using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Empregado e = new Empregado(nome, "12312312312", 10000, 1);

            Console.WriteLine(e);

        }
    }
}
