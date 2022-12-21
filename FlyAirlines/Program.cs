using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace FlyAirlines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aeronave a = new Aeronave();
            Piloto p = new Piloto();
            Voo v = new Voo();

            //Criando variável para utilizar a conexão
            SqlConnection sqlConnection;

            //string de conexão com o SQL Server
            string connectionString = @"Data Source=HELIOCAMELO;Initial Catalog=db_voeairlines;Integrated Security=True";

            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Conexão estabelecida com sucesso!");

                //Comando insert
                Console.Write("Insira o nome do fabricante da aeronave: ");
                a.Fabricante = Console.ReadLine();
                Console.Write("Digite o modelo da aeronave: ");
                a.Modelo = Console.ReadLine();
                Console.Write("Digite o código da aeronave: ");
                a.Codigo = Console.ReadLine();

                Console.Write("Insira o nome do piloto: ");
                p.Nome = Console.ReadLine();
                Console.Write("Insira a matrícula: ");
                p.Matricula = int.Parse(Console.ReadLine());

                Console.Write("Insira a origem do voo: ");
                v.Origem = Console.ReadLine();
                Console.Write("Insira a matrícula: ");
                v.Destino = Console.ReadLine();

                string insertQueryAeronave = "insert into aeronave(fabricante, modelo, codigo) " +
                    "values " +
                    "('"+a.Fabricante+"', '"+a.Modelo+"', '"+a.Codigo+"')";

                string insertQueryPiloto = "insert into piloto(nome, matricula) " +
                    "values " +
                    "('" + p.Nome + "', '" + p.Matricula + "')";

                string insertQueryVoo = "insert into piloto(nome, matricula) " +
                   "values " +
                   "('" + v.Origem + "', '" + v.Destino + "')";

                SqlCommand insertCommandA = new SqlCommand(insertQueryAeronave, sqlConnection);
                insertCommandA.ExecuteNonQuery();

                SqlCommand insertCommandP = new SqlCommand(insertQueryPiloto, sqlConnection);
                insertCommandP.ExecuteNonQuery();

                SqlCommand insertCommandV = new SqlCommand(insertQueryVoo, sqlConnection);
                insertCommandV.ExecuteNonQuery();

                Console.WriteLine("Dados inseridos com sucesso!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
