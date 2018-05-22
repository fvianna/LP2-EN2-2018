using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4
{
    class Program
    {
        static int larg = 80;
        static int alt = 30;

        static void Main(string[] args)
        {
            Robo reginaldo = new Robo();
            reginaldo.x = larg/2;
            reginaldo.y = alt/2;

            ConsoleKey tecla;

            do
            {
                MostrarRobo(reginaldo);

                tecla = Console.ReadKey().Key;
                if (tecla == ConsoleKey.UpArrow)
                {
                    reginaldo.y--;
                    if (reginaldo.y < 0)
                        reginaldo.y = alt-1;
                }
                if (tecla == ConsoleKey.DownArrow)
                {
                    reginaldo.y++;
                    if (reginaldo.y == alt)
                        reginaldo.y = 0;
                }
                if (tecla == ConsoleKey.LeftArrow)
                {
                    reginaldo.x--;
                    if (reginaldo.x < 0)
                        reginaldo.x = larg-1;
                }
                if (tecla == ConsoleKey.RightArrow)
                {
                    reginaldo.x++;
                    if (reginaldo.x == larg)
                        reginaldo.x = 0;
                }

            } while (tecla != ConsoleKey.Escape);

            Console.WriteLine("Terminou...");
        }

        public static void MostrarRobo(Robo r)
        {
            Console.Clear();
            for(int i=0; i < larg*(r.y)+(r.x); i++)
            {
                Console.Write(" ");
            }

            Console.Write("#");
        }

        static void AulaObjeto()
        {
            Console.WriteLine("Aluno 1");
            Aluno al = new Aluno();

            Console.Write("Nome: ");
            al.Nome = Console.ReadLine();  //Xico

            Console.Write("Ano de nascimento: ");
            al.AnoNasc = int.Parse(Console.ReadLine()); //1988


            Console.WriteLine("Aluno 2");
            Aluno al2 = new Aluno();

            Console.Write("Nome: ");
            al2.Nome = Console.ReadLine(); //Cláudio

            Console.WriteLine("Ano de nascimento: ");
            al2.AnoNasc = int.Parse(Console.ReadLine()); //2002


            Console.WriteLine("{0} nasceu em {1}", al.Nome, al.AnoNasc); //Xico nasceu em 1988
            Console.WriteLine("{0} nasceu em {1}", al2.Nome, al2.AnoNasc);//Cláudio nasc em 2002

            Aluno tmp = al2;
            al2 = al;

            al.Nome = "Teste";
            Console.WriteLine("{0} nasceu em {1}", al.Nome, al.AnoNasc); //Teste nasceu em 1988
            Console.WriteLine("{0} nasceu em {1}", al2.Nome, al2.AnoNasc);//Teste nasceu em 1988
            Console.WriteLine("{0} nasceu em {1}", tmp.Nome, tmp.AnoNasc);//Cláudio nasceu em 2002

        }

        static void AulaObjetoIN207()
        {

            Aluno aluno1 = new Aluno();

            Console.WriteLine("Dados do aluno 1:");
            Console.Write("Nome: ");
            aluno1.Nome = Console.ReadLine();
            //Console.Write("Telefone: ");
            //aluno1.Telefone = Console.ReadLine();
            Console.Write("Ano nascimento: ");
            aluno1.AnoNasc = int.Parse(Console.ReadLine());
            //Console.Write("Nota 1a Cert.: ");
            //aluno1.Nota1c = double.Parse(Console.ReadLine());


            Aluno aluno2 = new Aluno();

            Console.WriteLine("Dados do aluno 2:");
            Console.Write("Nome: ");
            aluno2.Nome = Console.ReadLine();
            //Console.Write("Telefone: ");
            //aluno2.Telefone = Console.ReadLine();
            Console.Write("Ano nascimento: ");
            aluno2.AnoNasc = int.Parse(Console.ReadLine());
            //Console.Write("Nota 1a Cert.: ");
            //aluno2.Nota1c = double.Parse(Console.ReadLine());

            Console.WriteLine("{0} nasceu em {1}", aluno1.Nome, aluno1.AnoNasc);
            Console.WriteLine("{0} nasceu em {1}", aluno2.Nome, aluno2.AnoNasc);

            aluno1 = aluno2;

            Console.WriteLine("{0} nasceu em {1}", aluno1.Nome, aluno1.AnoNasc);
            Console.WriteLine("{0} nasceu em {1}", aluno2.Nome, aluno2.AnoNasc);

            aluno1.Nome = "Alexsander";

            Console.WriteLine("{0} nasceu em {1}", aluno1.Nome, aluno1.AnoNasc);
            Console.WriteLine("{0} nasceu em {1}", aluno2.Nome, aluno2.AnoNasc);
        }
    }
}
