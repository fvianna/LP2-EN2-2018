using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula3_ManipulacaoInformacoes
{
    class Program
    {
        static string[] nomes;
        static string[] telefones;
        static int[] anosNasc;
        static char[] generos;
        static double[] notas1c;
        static double[] notas2c;
        static double[] notas3c;
        static double[] medAnual;

        static void Main(string[] args)
        {
            Console.Write("Quantidade de alunos a ser cadastrado: ");
            int n = int.Parse(Console.ReadLine());

            nomes = new string[n];
            telefones = new string[n];
            anosNasc = new int[n];
            generos = new char[n];
            notas1c = new double[n];
            notas2c = new double[n];
            notas3c = new double[n];
            medAnual = new double[n];

            Console.WriteLine("=============== CADASTRO =================");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Informe os dados do {0}º aluno", i + 1);
                Console.Write("Nome: ");
                nomes[i] = Console.ReadLine();

                Console.Write("Telefone: ");
                telefones[i] = Console.ReadLine();

                Console.Write("Ano de nascimento: ");
                anosNasc[i] = int.Parse(Console.ReadLine());

                Console.Write("Gênero: ");
                generos[i] = Console.ReadLine()[0];

                Console.Write("Nota 1C: ");
                notas1c[i] = double.Parse(Console.ReadLine());

                Console.Write("Nota 2C: ");
                notas2c[i] = double.Parse(Console.ReadLine());

                Console.Write("Nota 3C: ");
                notas3c[i] = double.Parse(Console.ReadLine());

                Console.WriteLine("");
                medAnual[i] = (3 * notas1c[i] + 3 * notas2c[i] + 4 * notas3c[i]) / 10;
            }


            Console.WriteLine("=============== RELATÓRIO =================");
            for (int i = 0; i < n; i++)
                RelatorioDeAluno(i);

        }

        public static void RelatorioDeAluno(int n)
        {
            string desGen = ((generos[n] == 'F') ? ("A") : ("O"));
            string situacao = "";

            if (medAnual[n] >= 7)
                situacao = "APROVAD";
            else if (medAnual[n] >= 5)
            {
                situacao = "RECUPERAÇÃO";
                desGen = "";
            }
            else
                situacao = "REPROVAD";

            Console.WriteLine("{0}: {1}{2}", nomes[n], situacao, desGen);

        }
    }
}
