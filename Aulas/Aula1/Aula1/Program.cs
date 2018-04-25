using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá!");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for(int i=m; i <= n; i += m)
            {
                if (i % m == 0)
                    Console.Write("{0} ", i);
            }
            /*for (int i = 1; i <= n; i++)
            {
                if (i % m == 0)
                    Console.Write("{0} ", i);
            }*/


        }
    }
}
