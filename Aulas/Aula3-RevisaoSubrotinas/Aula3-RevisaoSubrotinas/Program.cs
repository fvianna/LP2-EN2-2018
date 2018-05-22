using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula3_RevisaoSubrotinas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A idade do Xico é {0} anos.", CalculaIdade(27, 2, 1988));

            Console.WriteLine("E a sua idade? Qual será?");
            Console.Write("Data de nascimento (DD/MM/AAAA): ");
            string aux = Console.ReadLine();

            string[] partes = aux.Split('/');
            int d = int.Parse(partes[0]);
            int m = int.Parse(partes[1]);
            int a = int.Parse(partes[2]);

            int idade = CalculaIdade(d, m, a);
            Console.WriteLine("Você têm {0} anos.", idade);
        }

        public static int CalculaIdade(int dia, int mes, int ano)
        {
            // Desafio: Como obter sempre, automaticamente, a data "de hoje"? 
            // (Ou seja: a data atual na hora que o programa é executado?)
            // Dica: Procure por C# DateTime no Google.

            int anoAtual = 2018, mesAtual = 5, diaAtual = 15;

            int idade = anoAtual - ano;

            if (mesAtual < mes)
                idade--;
            else if (mesAtual == mes && diaAtual < dia)
                idade--;

            return idade;
        }
    }
}
