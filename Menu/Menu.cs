using System;
using System.Data;
using System.Globalization;
using System.IO.Pipes;
using RegistroAutomovel_V1.Servico;

namespace RegistroAutomovel_V1.Menu
{
    public class Menu
    {
        public ServicoRegistroAuto registro = new ServicoRegistroAuto();
        public Menu()
        {
            // adicao de proprietarios na tabela 
            registro.RegistrarProprietario(123456789, "João Silva", "123456789", new DateTime(1990, 5, 15));
            registro.RegistrarProprietario(987654321, "Maria Santos", "987654321", new DateTime(1985, 9, 25));
        
            // Adição de veículos na tabela
            registro.RegistrarVeiculo("ABC123", "Renault", "Clio", 2020, DateTime.Now, "Gasolina", "Azul", 5);
            registro.RegistrarVeiculo("DEF456", "Renault", "Clio", 2018, DateTime.Now, "Diesel", "Preto", 4);
            registro.RegistrarVeiculo("GHI789", "Seat", "Ibiza", 2015, DateTime.Now, "Gasolina", "Vermelho", 7);
            
        }

        public void ShowMenu()
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("||                Menu                 ||");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Comprar veículo novo");
                Console.WriteLine("2. Comprar veículo de segunda mão");
                Console.WriteLine("3. Procurar proprietários por nome");
                Console.WriteLine("4. Procurar veículo por matrícula");
                Console.WriteLine("5. Remover veículo");
                Console.WriteLine("6. Registrar falecimento de proprietário");
                Console.WriteLine("7. Listar Todos Veiculos");
                Console.WriteLine("8. Listar Todos Proprietarios");
                Console.WriteLine("0. Sair");
                Console.WriteLine();

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            ComprarVeiculoNovo();
                            break;
                        case "2":
                            ComprarVeiculoSegundaMao();
                            break;
                        case "3":
                            ProcurarProprietariosPorNome();
                            break;
                        case "4":
                            ProcurarVeiculoPorMatricula();
                            break;
                        case "5":
                            RemoverVeiculo();
                            break;
                        case "6":
                            RegistrarFalecimentoProprietario();
                            break;
                        case "7":
                            ListarTodosVeiculos();
                            break;
                        case "8":
                            ListarTodosProprietarios();
                            break;
                        case "0":
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Pressione Enter para continuar.");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    Console.WriteLine("Pressione Enter para continuar.");
                    Console.ReadLine();
                }
            }
        }

        private void ListarTodosProprietarios()
        {
            foreach (var proprietario in registro.ObterTodosProprietarios())
            {
                Console.WriteLine(proprietario);
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }

        private void ListarTodosVeiculos()
        {
            foreach (var veiculo in registro.ObterTodosVeiculos())
            {
                Console.WriteLine(veiculo);
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }

        private void ComprarVeiculoNovo()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("||         Comprar Veículo Novo        ||");
            Console.WriteLine("=========================================");
            Console.WriteLine("Verificar Proprietário Existente");
            Console.Write("NIF do Proprietário: ");
            int nifProprietario = int.Parse(Console.ReadLine());

             
            if (!registro.ExisteProprietario(nifProprietario))
            {
                Console.WriteLine("Proprietário não encontrado. Deseja criar um novo Proprietário? (S/N)");
                string resposta = Console.ReadLine();
                if (resposta.ToUpper() == "S")
                {
                    Console.Write("NIF do Proprietário: ");
                    int nif = int.Parse(Console.ReadLine());
                    Console.Write("Nome Completo do Proprietário: ");
                    string nomeCompleto = Console.ReadLine();
                    Console.Write("Número de Contato do Proprietário: ");
                    string numeroContato = Console.ReadLine();
                    Console.Write("Data de Nascimento do Proprietário (DD/MM/AAAA): ");
                    DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    registro.RegistrarProprietario(nif, nomeCompleto, numeroContato, dataNascimento);
                }
                else
                {
                    Console.WriteLine("Pressione Enter para continuar.");
                    Console.ReadLine();
                    return; // Abortar a compra do veículo
                }
            }

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Ano de Construção: ");
            int anoConstrucao = int.Parse(Console.ReadLine());
            Console.Write("Data de Início de Circulação (DD/MM/AAAA): ");
            DateTime dataInicioCirculacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Combustível: ");
            string combustivel = Console.ReadLine();
            Console.Write("Cor: ");
            string cor = Console.ReadLine();
            Console.Write("Lugares: ");
            int lugares = int.Parse(Console.ReadLine());

            registro.RegistrarVeiculo(matricula,marca,modelo,anoConstrucao,dataInicioCirculacao,combustivel,cor,lugares);
            registro.ComprarVeiculoNovo(nifProprietario, registro.ObterVeiculo(matricula));

            Console.WriteLine("Veículo comprado com sucesso!");
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }
        

        private void ComprarVeiculoSegundaMao()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("||    Comprar Veículo Segunda Mão      ||");
            Console.WriteLine("=========================================");
            Console.WriteLine("Veiculo já existente ? (S/N)");
            string resposta = Console.ReadLine();
            string immat = "";
            int nifComprador = 0;
            if (resposta.ToUpper() == "S")
            {
                bool sentinela = true;
                while (sentinela)
                {
                    Console.WriteLine("Insira a matrícula do veículo que pretende adquirir: ");
                    immat = Console.ReadLine();
                    if (registro.ExisteVeiculo(immat))
                    {
                        sentinela = true;
                    }
                    else if (!registro.ExisteVeiculo(immat))
                    {
                        Console.Clear();
                        Console.WriteLine("Veiculo não encontrado. Tente novamente!!");

                        ComprarVeiculoSegundaMao();
                    }
                }
            }
            else
            {
                Console.Write("Matrícula: ");
                string matricula = Console.ReadLine();
                Console.Write("Marca: ");
                string marca = Console.ReadLine();
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Ano de Construção: ");
                int anoConstrucao = int.Parse(Console.ReadLine());
                Console.Write("Data de Início de Circulação (DD/MM/AAAA): ");
                DateTime dataInicioCirculacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Combustível: ");
                string combustivel = Console.ReadLine();
                Console.Write("Cor: ");
                string cor = Console.ReadLine();
                Console.Write("Lugares: ");
                int lugares = int.Parse(Console.ReadLine());
                registro.RegistrarVeiculo(matricula,marca,modelo,anoConstrucao,dataInicioCirculacao,combustivel,cor,lugares);
            }
            Console.WriteLine("O comprador já se encontra Registrado ? (S/N)");
            string resposta2 = Console.ReadLine();
            if (resposta2.ToUpper() == "S")
            {
                Console.WriteLine("Insira a o Número de Identificação Fiscal  do Comprador ");
                nifComprador = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Insira os dados do Proprietário para Registrar: ");
                Console.Write("NIF do Proprietário: ");
                int nif = int.Parse(Console.ReadLine());
                Console.Write("Nome Completo do Proprietário: ");
                string nomeCompleto = Console.ReadLine();
                Console.Write("Número de Contato do Proprietário: ");
                string numeroContato = Console.ReadLine();
                Console.Write("Data de Nascimento do Proprietário (DD/MM/AAAA): ");
                DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                registro.RegistrarProprietario(nif, nomeCompleto, numeroContato, dataNascimento);
            }

            registro.ComprarVeiculoEmSegundaMao(nifComprador, registro.ObterVeiculo(immat));

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        private void ProcurarProprietariosPorNome()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("||    Procurar Proprietário Por Nome   ||");
            Console.WriteLine("=========================================");
            Console.Write("Digite o nome ou parte do nome: ");
            string nome = Console.ReadLine();

            

            Console.WriteLine("Resultados:");
            foreach (var proprietario in registro.EncontrarProprietarioPorNome(nome))
            {
                Console.WriteLine(proprietario);
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }

        private void ProcurarVeiculoPorMatricula()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("||         Procurar  Veículo           ||");
            Console.WriteLine("=========================================");
            Console.Write("Digite a matrícula: ");
            string matricula = Console.ReadLine();
            
            registro.ObterVeiculo(matricula);

            if (registro.ExisteVeiculo(matricula))
            {
                Console.WriteLine(registro.ObterVeiculo(matricula));
           
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }

        private void RemoverVeiculo()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("||           Remover Veículo           ||");
            Console.WriteLine("=========================================");
            Console.Write("Digite a matrícula do veículo a ser removido: ");
            string matricula = Console.ReadLine();

            registro.RemoverVeiculo(matricula);

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }

        private void RegistrarFalecimentoProprietario()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("||          Obito Proprietario         ||");
            Console.WriteLine("=========================================");
            Console.Write("Digite o NIF do proprietário falecido: ");
            int nif = int.Parse(Console.ReadLine());

            registro.RegistrarFalecimentoProprietario(nif);

            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
            ShowMenu();
        }
    }
}