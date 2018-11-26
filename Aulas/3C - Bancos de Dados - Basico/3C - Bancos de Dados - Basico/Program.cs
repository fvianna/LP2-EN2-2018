using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3C___Bancos_de_Dados___Basico
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultaAlunos();
            //MainOpsBd();
        }

        static void MainOpsBd()
        {
            int op = Menu();
            while(op != 0)
            {
                switch (op)  //escolha de opções
                {
                    case 1: { InserirPessoas(); break; }
                    case 2: { DeletarPessoas(); break; }
                    case 3: { ConsultarPessoas(); break; }
                }

                op = Menu();
            }
        }

        static string Linha(int tam, bool borda = false)
        {
            string c = (borda ? "|" : " ");
            string x = c;
            for(int i=0; i<tam-2; i++)
                x += "-";

            return x + c;
        }

        static void ConsultarPessoas()
        {
            Console.Clear();

            Console.WriteLine("Consulta de Alunos:\n");
            //Console.Write("Nome: ");
            //string nome = Console.ReadLine();

            SqlConnection conexao = new SqlConnection(
                @"Data Source = EN2LIC00;
                    Initial Catalog = AulaLP2;
                    Integrated security = SSPI;");

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"
                    SELECT a.Id, a.Nome, a.Sobrenome, t.Nome
                    FROM ALUNO a, TURMA t
                    WHERE t.Id = a.IdTurma
                    ORDER BY t.Nome, a.Nome, a.Sobrenome;";

            // Exibindo o comando final produzido com o string.Format e que será executado
            // Console.WriteLine("Comando: {0}", comando.CommandText);

            conexao.Open();
            SqlDataReader reader = comando.ExecuteReader();

            string cabecalho = String.Format("{0,-6}|{1,-16}|{2,-16}|{3,-10}|", "ID", "NOME", "SOBRENOME", "TURMA");

            Console.WriteLine(Linha(cabecalho.Length, true));
            Console.WriteLine(cabecalho);
            Console.WriteLine(Linha(cabecalho.Length, true));

            List<Aluno> pessoas = new List<Aluno>();

            while (reader.Read())
            {
                Aluno p = new Aluno() {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Sobrenome = reader.GetString(2),
                    Turma = reader.GetString(3)
                };

                pessoas.Add(p);
                Console.WriteLine("{0,-6}|{1,-16}|{2,-16}|{3,-10}|", p.Id, p.Nome, p.Sobrenome, p.Turma);
            }

            Console.WriteLine(Linha(cabecalho.Length, true));

            conexao.Close();
            Console.WriteLine("\nAperte qualquer tecla para retornar ao menu...");
            Console.ReadKey();
        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Controle de Alunos:\n");
            Console.WriteLine("1 - Inserir alunos");
            Console.WriteLine("2 - Remover alunos");
            Console.WriteLine("3 - Consultar alunos cadastrados");
            Console.Write("\nOpção: ");

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

        static void DeletarPessoas()
        {
            ConsoleKeyInfo outro;

            do
            {
                Console.Clear();
                Console.WriteLine("Deletar um Aluno");

                Console.Write("\nNome: ");
                string nome = Console.ReadLine();
                Console.Write("Sobrenome: ");
                string sobrenome = Console.ReadLine();
                SqlConnection conexao = new SqlConnection(
                    @"Data source = EN2LIC00;
                      Initial catalog = AulaLP2;
                      Integrated security = SSPI;");

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = @"
                      DELETE FROM ALUNO
                      WHERE Nome = @nome AND Sobrenome = @sobre;";

                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@sobre", sobrenome);

                // Exibindo o comando final produzido com o string.Format e que será executado
                // Console.WriteLine("Comando: {0}", comando.CommandText);

                conexao.Open();
                int result = comando.ExecuteNonQuery();
                conexao.Close();

                if (result > 0)
                    Console.WriteLine("Registro removido com sucesso.");
                else
                    Console.WriteLine("Algo deu errado");

                Console.Write("Deseja remover outro (S/N)? ");
                outro = Console.ReadKey();

            } while (outro.Key == ConsoleKey.S);

        }


        static void ConsultaAlunosPorIdade()
        {
            Console.WriteLine("Consulta de Alunos por idade\n");

            Console.Write("Minimo: ");
            int idadeMin = int.Parse(Console.ReadLine());
            Console.Write("Máximo: ");
            int idadeMax = int.Parse(Console.ReadLine());

            SqlConnection conexao = new SqlConnection(
                @"Data source = EN2LIC00;
                  Initial catalog = AulaLP2;
                  Integrated security = SSPI;"
            );

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"
                SELECT * FROM ALUNO
                WHERE Idade >= @imin AND Idade <= @imax
                ORDER BY Nome, Sobrenome;";

            comando.Parameters.AddWithValue("@imin", idadeMin);
            comando.Parameters.AddWithValue("@imax", idadeMax);

            conexao.Open();
            SqlDataReader reader = comando.ExecuteReader();

            if(reader.HasRows)
            {
                string cabecalho = String.Format("|{0,-12}|{1,-12}|{2,-5}|", "NOME", "SOBRENOME", "IDADE");
                Console.WriteLine("\n{0}", Linha(cabecalho.Length));
                Console.WriteLine(cabecalho);
                Console.WriteLine("{0}", Linha(cabecalho.Length, true));

                while (reader.Read())
                {
                    string nome = reader.GetString(1);
                    string sobrenome = reader.GetString(2);
                    int idade = reader.GetInt32(3);

                    Console.WriteLine("|{0,-12}|{1,-12}|{2,-5}|", nome, sobrenome, idade);
                }
                Console.WriteLine(Linha(cabecalho.Length));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nenhum registro encontrado");
            }

            conexao.Close();
        }
    }
}
