using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Gabarito_3a_Questao
{
    class Casa
    {
        public string Nome;
        public int Pontos;
        public int QtdAlunos;

        public void DarPontos(int pts)
        {
            Pontos += pts;
        }

        public void TirarPontos(int pts)
        {
            Pontos -= pts;
            if (Pontos < 0)
                Pontos = 0;
        }

        public void Situacao()
        {
            Console.WriteLine("{0}: {1} pontos", Nome, Pontos);
        }

        public bool AtingiuCE()
        {
            double media = Pontos / QtdAlunos;
            if (media >= 15)
                return true;
            else
                return false;

            // O bloco poderia ser mais facilmente escrito da seguinte forma:
            // return (Pontos / QtdAlunos >= 15);
        }

    }
}
