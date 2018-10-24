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
            char outro;

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
                comando.CommandText = string.Format(@"
                      INSERT INTO ALUNO (Nome, Sobrenome, Idade)
                      VALUES ('{0}', '{1}', {2});", nome, sobrenome, idade);

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
                outro = Console.ReadKey().KeyChar;

            } while (outro == 'S');
        }
    }
}
