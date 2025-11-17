using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Atividade_CSharp
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public string Sus { get; private set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }




        public void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("Informe seu Nome:");
            this.Nome = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe seu CPF:");
            this.Cpf = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe o Numero do seu Cartao do SUS:");
            this.Sus = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe sua Idade:");
            this.Idade = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Informe seu Endereco:");
            this.Endereco = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe seu Telefone:");
            this.Telefone = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Informe seu Email:");
            this.Email = Console.ReadLine();
        }

        public void Consultar(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                Console.Clear();
                Console.WriteLine("Erro. Tente Novamente!");
            }

            if (cpf == this.Cpf)
            {
                string resposta = "S";
                while (resposta == "S")
                {
                    Console.Clear();
                    Console.WriteLine("=================================================================");
                    Console.WriteLine("Selecione o numero correspondente a alteracao que deseja realizar\n 1. Nome. \n 2. Idade. \n 3. Endereco. \n 4. Telefone. \n 5. Email. \n 6. Exibir Dados \n 0. Voltar pro Menu.");
                    Console.WriteLine("=================================================================");
                    string numero = Console.ReadLine();
                    switch (numero)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Digite seu nome:");
                            this.Nome = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Deseja continuar alterações? (S/N)");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            Console.Clear();
                            if (resposta != "S" && resposta != "N")
                            {
                                Console.WriteLine("Opcao Invalida. Voltando ao Menu.");
                                resposta = "N";
                            }
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Digite sua Idade:");
                            this.Idade = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Deseja continuar alterações? (S/N)");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            Console.Clear();
                            if (resposta != "S" && resposta != "N")
                            {
                                Console.WriteLine("Opcao Invalida. Voltando ao Menu.");
                                resposta = "N";
                            }
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Digite seu Endereco:");
                            this.Endereco = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Deseja continuar alterações? (S/N)");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            Console.Clear();
                            if (resposta != "S" && resposta != "N")
                            {
                                Console.WriteLine("Opcao Invalida. Voltando ao Menu.");
                                resposta = "N";
                            }
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Digite seu Telefone:");
                            this.Telefone = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Deseja continuar alterações? (S/N)");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            Console.Clear();
                            if (resposta != "S" && resposta != "N")
                            {
                                Console.WriteLine("Opcao Invalida. Voltando ao Menu.");
                                resposta = "N";
                            }
                            break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("Digite seu Email:");
                            this.Email = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("Deseja continuar alterações? (S/N)");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            Console.Clear();
                            if (resposta != "S" && resposta != "N")
                            {
                                Console.WriteLine("Opcao Invalida. Voltando ao Menu.");
                                resposta = "N";
                            }
                            break;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("|********** SEUS DADOS **********|\n");
                            Console.WriteLine($"Nome: {this.Nome}\nIdade: {this.Idade}\nEndereco: {this.Endereco}\nTelefone: {this.Telefone}\nEmail: {this.Email}");
                            Console.WriteLine("\n\nDeseja continuar alterações? (S/N)");
                            resposta = Console.ReadLine();
                            resposta = resposta.ToUpper();
                            Console.Clear();
                            if (resposta != "S" && resposta != "N")
                            {
                                Console.WriteLine("Opcao Invalida. Voltando ao Menu.");
                                resposta = "N";
                            }
                            break;

                        case "0":
                            Console.Clear();
                            resposta = "N";
                            break;

                        default:
                            Console.WriteLine("Opção Invalida.");
                            break;
                    }
                }
            }
        }
    }
}