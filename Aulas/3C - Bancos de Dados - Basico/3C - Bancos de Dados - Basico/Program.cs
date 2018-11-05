using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _3C___Bancos_de_Dados___Basico
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = Menu();
            while(op != 0)
            {
                switch (op)  //escolha de opções
                {
                    case 1: { InserirPessoas(); break; }
                    case 2: { DeletarPessoa(); break; }
                }

                op = Menu();
            }
        }

        static int Menu()
        {
            Console.WriteLine("Controle de pessoas:\n");
            Console.WriteLine("1 - Inserir pessoas");
            Console.WriteLine("2 - Remover pessoas");
            Console.Write("Opção: ");

            int resp = int.Parse(Console.ReadLine());
            return resp;
        }

        static void InserirPessoas()
        {
            ConsoleKeyInfo outro;

            do
            {
                Console.Clear();

                Console.WriteLine("Cadastro de Alunos");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Sobrenome: ");
                string sobrenome = Console.ReadLine();

                Console.Write("Idade: ");
                int idade = int.Parse(Console.ReadLine());

                SqlConnection conexao = new SqlConnection(
                    @"Data source = EN2LIC00;
                      Initial catalog = AulaLP2;
                      Integrated security = SSPI;");

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = @"
                      INSERT INTO ALUNO (Nome, Sobrenome, Idade)
                      VALUES (@nome, @sobre, @idade);";

                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@sobre", sobrenome);
                comando.Parameters.AddWithValue("@idade", idade);

                // Exibindo o comando final produzido com o string.Format e que será executado
                // Console.WriteLine("Comando: {0}", comando.CommandText);

                conexao.Open();
                int result = comando.ExecuteNonQuery();
                conexao.Close();

                if (result > 0)
                    Console.WriteLine("Registro foi inserido com sucesso.");
                else
                    Console.WriteLine("Algo deu errado");

                Console.Write("Deseja inserir outro (S/N)? ");
                outro = Console.ReadKey();

            } while (outro.Key == ConsoleKey.S);
        }

        static void DeletarPessoa()
        {
            Console.WriteLine("Deletar uma Pessoa");

            Console.Write("\nNome: ");
            string nome = Console.ReadLine();
            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();



            //Interação com o BD
            // CommandText passa a ser um DELETE



            Console.WriteLine("Registro removido com sucesso.");
        }
    }
}
