using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoProva
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> alunos = new List<Aluno>();

            //Passo 1 - Instanciar um novo objeto SqlConnection
            string stringConexao = "Data Source = EN2LIC00; Initial Catalog = AulaLP2; Integrated Security = SSPI";
            SqlConnection conexao = new SqlConnection(stringConexao);

            //Passo 2 - Instanciar um objeto SqlCommand
            SqlCommand comando = new SqlCommand();

            //Passo 3 - Configurando o atributo Connection no objeto SqlCommand
            comando.Connection = conexao;

            //Passo 4 - Configurando o atributo CommandText no objeto SqlCommand
            //Exemplo: Selecionar alunos com no máximo a idade dada pelo usuário
            comando.CommandText = @"SELECT Sobrenome, Nome, Idade FROM ALUNO
                                    WHERE Idade = @idade;";

            //Passo 5 - Adicionando valores aos parâmetros do comando, uma vez que
            //na minha consulta um valor que virá de uma interação com o usuário
            Console.Write("Idade para consulta: ");
            int idadeConsulta = int.Parse(Console.ReadLine());
            comando.Parameters.AddWithValue("@idade", idadeConsulta);

            //Passo 6 - Abrir a conexão
            conexao.Open();

            //Passo 7 - EXECUTA O SQL QUE FOI DEVIDAMENTE PREPARADO EM 
            //TODAS AS ETAPAS ANTERIORES
            SqlDataReader reader = comando.ExecuteReader();

            //Passo 8 - Realizar o processamento necessário para extrair os
            //dados da tabela retornada pela consulta (armazenada em reader)

            if(reader.HasRows) // 8.1 - Se o reader tem linhas
            {
                while(reader.Read()) // 8.2 - Iterarpor todos os registros retornados
                {
                    // 8.3 - Realizar o processamento de cada uma das linhas 
                    // retornadas pela consulta
                    Aluno a = new Aluno();
                    a.Sobrenome = reader.GetString(0);
                    a.Nome = reader.GetString(1);
                    a.Idade = reader.GetInt32(2);
                    alunos.Add(a);

                    Console.WriteLine("{0}, {1} - {2} anos", a.Sobrenome, a.Nome, a.Idade);
                }
            }
            else
            {
                Console.WriteLine("Nada foi encontrado.");
            }

            //Passo Final - Fechar a conexão
            conexao.Close();

            Console.WriteLine("\nTodos os nomes:");
            for(int i = 0; i < alunos.Count; i++)
            {
                Console.WriteLine(alunos[i].Nome);
            }

            Console.WriteLine("\nTodos os sobrenomes:");
            foreach(Aluno al in alunos)
            {
                Console.WriteLine(al.Sobrenome);
            }
        }
    }
}
