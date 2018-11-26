using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Perfil
{
    class Program
    {
        static void Main(string[] args)
        {
            string continua;
            do
            {
                Carta carta = SortearCarta();
                bool jogoRolando = true;

                while (jogoRolando)
                {
                    Console.WriteLine(carta);

                    int dicaPedida = PedirNovaDica();
                    carta.RegistrarDica(dicaPedida);

                    string palpite = PedirPalpite();

                    jogoRolando = carta.ProcessarPalpite(palpite);
                }

                Console.Write("Deseja jogar novamente? ");
                continua = Console.ReadLine();
            } while (continua == "S");
        }

        private static string PedirPalpite()
        {
            Console.Write("Digite seu palpite: ");
            return Console.ReadLine();
        }

        private static int PedirNovaDica()
        {
            Console.Write("Nova dica: ");
            int Nova = int.Parse(Console.ReadLine());
            return Nova;
        }


        private static Carta SortearCarta()
        {
            SqlConnection Conexao = new SqlConnection(@"
                Data source = EN2LIC00;
                Initial catalog = Perfil;
                Integrated security = SSPI;"
            );

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao;
            cmd.CommandText = @"
                SELECT TOP 1 c.Id, cat.Nome, c.Resposta 
                FROM Carta c, Categoria cat 
                WHERE cat.Id = c.IdCategoria 
                ORDER BY NEWID();";

            Conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            Carta nova = new Carta()
            {
                Id = reader.GetInt32(0),
                Resposta = reader.GetString(2),
                Categoria = reader.GetString(1),
                Dicas = new List<string>()
            };

            Conexao.Close();

            cmd.CommandText = @"
                SELECT Texto FROM Dica 
                WHERE IdCarta = @idc;";

            cmd.Parameters.AddWithValue("@idc", nova.Id);

            Conexao.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nova.Dicas.Add(reader.GetString(0));
            }


            nova.Usadas = new bool[nova.Dicas.Count];

            return nova;
        }
    }
}
