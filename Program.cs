using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu inicio = new Menu();
            Pessoa[] array = new Pessoa[15];
            MySqlConnection conexao;
            const int limite = 3;
            int contador;
            bool continuar = true;

            while (continuar)
            {

                conexao = new MySqlConnection("server=127.0.0.1;uid=root;pwd='1234';database=hospital; Port=3307");

                try
                {
                    conexao.Open();
                }
                catch (MySqlException erro)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados. \n" + erro.Message);
                }

                string bd = "SELECT contador FROM paciente ORDER BY contador DESC LIMIT 1";
                MySqlCommand cmdBd = new MySqlCommand(bd, conexao);
                object resultado = cmdBd.ExecuteScalar();
                contador = Convert.ToInt32(resultado);



                switch (inicio.Hud())
                {
                    case "1":
                        string res = "S";

                        while (res == "S" && contador < limite)
                        {
                            Pessoa paciente = new Pessoa();
                            paciente.Cadastrar();

                            array[contador] = paciente;

                            contador++;

                            Console.Clear();
                            string sqlInsert = "INSERT INTO paciente (Nome, Cpf, Sus, Idade, Endereco, Telefone, Email, Contador) VALUES (@nome, @cpf, @sus, @idade, @endereco, @telefone, @email, @contador)";
                            MySqlCommand cmd = new MySqlCommand(sqlInsert, conexao);
                            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
                            cmd.Parameters.AddWithValue("@cpf", paciente.Cpf);
                            cmd.Parameters.AddWithValue("@sus", paciente.Sus);
                            cmd.Parameters.AddWithValue("@idade", paciente.Idade);
                            cmd.Parameters.AddWithValue("@endereco", paciente.Endereco);
                            cmd.Parameters.AddWithValue("@telefone", paciente.Telefone);
                            cmd.Parameters.AddWithValue("@email", paciente.Email);
                            cmd.Parameters.AddWithValue("@contador", contador);

                            int linhas = cmd.ExecuteNonQuery();
                            Console.WriteLine("Paciente Cadastrado!! \n\nPressione ENTER para continuar...");
                            Console.ReadLine();
                            Console.Clear();


                            if (contador == limite)
                            {
                                Console.Clear();
                                Console.WriteLine("Paciente Cadastrado!! \n\nLimite de Pacientes Excedido\n\n");
                                Console.WriteLine("Pressione ENTER para voltar ao Menu...");
                                Console.ReadLine();
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Deseja Cadastrar Outro Paciente? (S/N)");
                                res = Console.ReadLine();
                                res = res.ToUpper();
                                Console.Clear();
                                Console.WriteLine("Pressione ENTER para continuar...");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            if (res != "S" && res != "N")
                            {
                                Console.Clear();
                                Console.WriteLine("Opção inválida. Voltando ao Menu.");
                                res = "N";
                                Console.Clear();
                            }
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine($"PACIENTES NA FILA ({contador + "/" + limite}):");
                        if (contador == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Não existem pacientes Cadastrados!\n\nPressione Enter para voltar ao Menu...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            string sqlSelect = "SELECT Nome FROM paciente ORDER BY Idade DESC";
                            MySqlCommand cmdLI = new MySqlCommand(sqlSelect, conexao);
                            MySqlDataReader reader = cmdLI.ExecuteReader();

                            while (reader.Read())
                            {
                                string nome = reader.GetString("Nome");
                                Console.WriteLine($"Nome: {nome}");
                            }

                            Console.WriteLine("\n\n\nPressione Enter para voltar ao Menu...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        if (contador == 0)
                        {
                            Console.WriteLine("A fila de atendimento está vazia!\n\n\nPressione ENTER para retornar ao Menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {

                            string sqlSelect = "SELECT Id, Nome, Idade FROM paciente ORDER BY Idade DESC";
                            MySqlCommand cmd = new MySqlCommand(sqlSelect, conexao);
                            MySqlDataReader reader = cmd.ExecuteReader();
                            
                            while (reader.Read())
                            {
                                string nome = reader.GetString("Nome");
                                int idade = reader.GetInt32("Idade");
                                int id = reader.GetInt32("Id");
                                Console.WriteLine($"O Paciente {nome} de {idade} anos, finalizou o atendimento!!\n\n");
                            }
                            reader.Close();

                            string sqlBusca = "SELECT Id FROM paciente ORDER BY Idade DESC";
                            MySqlCommand cmdId = new MySqlCommand(sqlBusca, conexao);
                            object buscaId = cmdId.ExecuteScalar();
                            int valorId = Convert.ToInt32(buscaId);


                            string sqlDelete = "DELETE FROM paciente WHERE id = @id";
                            MySqlCommand cmdDel = new MySqlCommand(sqlDelete, conexao);
                            cmdDel.Parameters.AddWithValue("@id", buscaId);
                            cmdDel.ExecuteNonQuery();

                            Console.WriteLine($"|*LISTA DE PACIENTES NA FILA ATUALIZADA ({contador - 1}/{limite})*|");
                            Console.WriteLine("\n\nPressione ENTER para retornar ao Menu");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case "4":
                        Console.Clear();
                        if (contador == 0)
                        {
                            Console.WriteLine("Não existe nenhum paciente cadastrado no sistema. Voltando ao Menu. \n\n\n");
                        }
                        else
                        {
                            Console.WriteLine("Digite o CPF do paciente que deseja alterar dados cadastrais:");
                            string cpfBusca = Console.ReadLine();
                            for (int y = 0; y < contador; y++)
                            {
                                array[y].Consultar(cpfBusca);
                            }
                        }
                        break;

                    case "Q":
                        Console.Clear();
                        continuar = false;
                        Console.WriteLine("Saindo do programa. Aperte ESC para fechar.");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Invalida! Tente Novamente:");
                        Console.WriteLine("Pressione ENTER para voltar ao Menu...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}