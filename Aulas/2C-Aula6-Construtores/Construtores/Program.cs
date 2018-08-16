using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrutores
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valido = false;
            while(!valido)
            {
                try
                {
                    Console.WriteLine("Novo Carro");

                    Console.Write("Modelo: ");
                    string mod = Console.ReadLine();

                    Console.Write("Placa: ");
                    string pl = Console.ReadLine();
                    Carro c1 = new Carro(mod, pl);

                    valido = true;
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro: {0}", e.Message);
                    Console.WriteLine("Repita a operação.\n");
                }
            }
        }
    }
}
