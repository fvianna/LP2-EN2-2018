using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Gabarito_3a_Questao
{
    class Program
    {
        static void Main(string[] args)
        {
            Casa c1 = new Casa();
            c1.Nome = "Lufa-Lufa";
            c1.Pontos = 35;
            c1.QtdAlunos = 126;

            c1.DarPontos(10);
            c1.DarPontos(5);
            c1.TirarPontos(2);
            c1.TirarPontos(15);

            c1.Situacao();

            if (c1.AtingiuCE())
                Console.WriteLine("{0} participará do torneio.", c1.Nome);
            else
                Console.WriteLine("{0} não participará do torneio.", c1.Nome);

            Casa c2 = new Casa();
            c2.Nome = "Sonserina";
            c2.Pontos = 120;
            c2.QtdAlunos = 35;

            c2.DarPontos(1000);
            c2.DarPontos(50);
            c2.TirarPontos(80);
            c2.TirarPontos(12);

            c2.Situacao();

            if (c2.AtingiuCE())
                Console.WriteLine("{0} participará do torneio.", c2.Nome);
            else
                Console.WriteLine("{0} não participará do torneio.", c2.Nome);
        }
    }
}
