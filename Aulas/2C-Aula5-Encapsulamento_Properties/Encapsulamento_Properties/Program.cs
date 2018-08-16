using System;

namespace Encapsulamento_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p = new Pessoa();

            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            p.Sobrenome = Console.ReadLine();

            Console.Write("Altere o nome completo da pessoa (Nome + sobrenome): ");
            p.NomeCompleto = Console.ReadLine(); //"Francisco Vianna"

            Console.WriteLine("Nome: {0}", p.Nome); // "Francisco"
            Console.WriteLine("Sobrenome: {0}", p.Sobrenome); //"Vianna"

            Console.WriteLine("Nome completo: {0}", p.NomeCompleto);
        }
    }
}
