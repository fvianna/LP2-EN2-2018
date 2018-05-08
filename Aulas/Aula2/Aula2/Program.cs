using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Triangulos();
            Estatistica();
        }




        static void Estatistica()
        {
            //Console.Write("Informe a quantidade de números: ");
            int qtd = int.Parse(Console.ReadLine());

            int[] nros = new int[qtd];

            for (int i = 0; i < qtd; i++)
            {
                //Console.Write("Informe o {0}º número: ", i + 1);
                nros[i] = int.Parse(Console.ReadLine());
            }

            //Calcula a média entre o primeiro e o último números da amostra.
            double conta = (nros[0] + nros[qtd - 1]) / 2.0;
            Console.WriteLine("Média: {0}", conta);

            //Exibe os números na ordem em quee foram armazenados
            Console.WriteLine("Na ordem dada:");
            for (int i = 0; i < qtd; i++)
            {
                Console.Write("{0} ", nros[i]);
            }

            //Ordena os elementos do vetor em ordem crescente
            Array.Sort(nros);

            //Exibe novamente os elementos, agora ordenados
            Console.WriteLine("\nOrdenado:");
            for (int i = 0; i < qtd; i++)
            {
                Console.Write("{0} ", nros[i]);
            }

            // Exercício: Terminar o código e para fazer o cálculo da mediana.
            // se quantidade é par:
            //     mediana é a média dos dois do meio
            // senao
            //     mediana o numero do meio

        }



        static void Triangulos()
        {
            // Faz a leitura do que será o tamanho do triângulo
            int n = int.Parse(Console.ReadLine());

            //Fase 0 - Imprimir apenas a base do triângulo
            for (int i = 0; i < n; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine("\n");


            //Fase 1 - Imprimir o triângulo completo (alinhado à esquerda)
            // for externo: Cada iteração gera uma nova linha de tamanho i
            for (int i = 1; i <= n; i++) //i -- Nro da linha atual, que é igual à quantidade de # na linha 
            {
                //for interno: Cada interação mostra um # da linha
                for (int j = 1; j <= i; j++) //j -- posição do proximo #
                {
                    Console.Write("#");
                }
                Console.WriteLine(""); // Ao final de uma linha do triângulo, é preciso passar para a próxima.
            }
            Console.WriteLine("");


            //Fase 2 - Imprimir o triângulo completo (alinhado à direita)
            for (int i = 0; i < n; i++)
            {
                int j; //O j é criado fora, porque preciso usar o mesmo contador para mostrar primeiro os espaços.... 
                for (j = 0; j < n - i - 1; j++)
                {
                    Console.Write(" ");
                }

                // ... e depois os # (reparem que eu não mexi no j, para continuar de onde parei
                for (; j < n; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine(""); // Ao final de uma linha do triângulo, é preciso passar para a próxima.
            }
            Console.WriteLine("\n");


            //Fase 3 - Imprimir somente o contorno do triangulo. Você consegue entender o que mudou da fase 1 para cá?
            for (int i = 1; i <= n; i++) //Limita a quantidade de linhas
            {
                for (int j = 1; j <= i; j++) // Limita o tamanho de cada linha
                {
                    if (i > 1 && i < n) //se não for nem a 1a ne a última linha
                    {
                        if (j == 1 || j == i) //só mostra # na primeira e na última posição da linha, o resto é espaço
                            Console.Write("#");
                        else
                            Console.Write(" ");
                    }
                    else // no caso de ser a 1a ou ultima linhas, mostra todos como #
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
