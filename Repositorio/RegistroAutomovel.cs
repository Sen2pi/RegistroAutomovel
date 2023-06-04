using RegistroAutomovel_V1.Modelo;
namespace RegistroAutomovel_V1.Repositorio
{
    public class RegistroAutomovel
    {
        private LinkedList<Proprietario> repositorioProprietarios;
        private List<Veiculo>[] repositorioVeiculos;

        public RegistroAutomovel()
        {
            repositorioProprietarios = new LinkedList<Proprietario>();
            repositorioVeiculos = new List<Veiculo>[10];
            for (int i = 0; i < 10; i++)
            {
                repositorioVeiculos[i] = new List<Veiculo>();
            }
        }

        public void InserirProprietario(Proprietario proprietario)
        {
            if (repositorioProprietarios.Find(proprietario) == null)
            {
                repositorioProprietarios.AddLast(proprietario);
            }
            else
            {
                Console.WriteLine("Proprietário com o mesmo NIF já existe.");
            }
        }

        public Proprietario ProcurarProprietario(int nif)
        {
            foreach (var proprietario in repositorioProprietarios)
            {
                if (proprietario.NIF == nif)
                {
                    return proprietario;
                }
            }

            return null;
        }

        public Proprietario[] ProcurarProprietariosPorNome(string nome)
        {
            List<Proprietario> resultados = new List<Proprietario>();
            foreach (var proprietario in repositorioProprietarios)
            {
                if (proprietario.NomeCompleto.Contains(nome))
                {
                    resultados.Add(proprietario);
                }
            }

            return resultados.ToArray();
        }

        public void EditarProprietario(int nif, Proprietario novoProprietario)
        {
            Proprietario proprietario = ProcurarProprietario(nif);
            if (proprietario != null)
            {
                proprietario.NomeCompleto = novoProprietario.NomeCompleto;
                proprietario.NumeroContacto = novoProprietario.NumeroContacto;
                proprietario.DataNascimento = novoProprietario.DataNascimento;
            }
            else
            {
                Console.WriteLine("Proprietário não encontrado.");
            }
        }

        public void RemoverProprietario(int nif)
        {
            Proprietario proprietario = ProcurarProprietario(nif);
            if (proprietario != null)
            {
                if (proprietario.Falecido)
                {
                    foreach (var veiculo in repositorioVeiculos)
                    {
                        if (veiculo.Proprietario == proprietario)
                        {
                            veiculo.Proprietario = null;
                        }
                    }

                    repositorioProprietarios.Remove(proprietario);
                }
                else
                {
                    Console.WriteLine("Não é possível remover um proprietário vivo.");
                }
            }
            else
            {
                Console.WriteLine("Proprietário não encontrado.");
            }
        }

        public void ComprarVeiculoNovo(Veiculo veiculo)
        {
            if (ProcurarVeiculoPorMatricula(veiculo.Matricula) == null)
            {
                repositorioVeiculos[Hash(veiculo.Matricula)].Add(veiculo);
            }
            else
            {
                Console.WriteLine("Veículo com a mesma matrícula já existe.");
            }
        }

        public void ComprarEVenderVeiculo(Veiculo veiculo, Proprietario novoProprietario)
        {
            if (ProcurarVeiculoPorMatricula(veiculo.Matricula) != null)
            {
                Veiculo veiculoExistente = ProcurarVeiculoPorMatricula(veiculo.Matricula);
                if (veiculoExistente.Proprietario == null)
                {
                    if (novoProprietario.Falecido)
                    {
                        Console.WriteLine("Uma pessoa falecida não pode adquirir um veículo.");
                    }
                    else
                    {
                        veiculoExistente.Proprietario = novoProprietario;
                    }
                }
                else
                {
                    Console.WriteLine("O veículo já possui um proprietário.");
                }
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        public Veiculo ProcurarVeiculoPorMatricula(string matricula)
        {
            foreach (var listaColisao in repositorioVeiculos[Hash(matricula)])
            {
                if (listaColisao.Matricula == matricula)
                {
                    return listaColisao;
                }
            }

            return null;
        }

        public void EditarVeiculo(string matricula, Veiculo novoVeiculo)
        {
            Veiculo veiculo = ProcurarVeiculoPorMatricula(matricula);
            if (veiculo != null)
            {
                veiculo.Marca = novoVeiculo.Marca;
                veiculo.Modelo = novoVeiculo.Modelo;
                veiculo.AnoConstrucao = novoVeiculo.AnoConstrucao;
                veiculo.DataInicioCirculacao = novoVeiculo.DataInicioCirculacao;
                veiculo.Proprietario = novoVeiculo.Proprietario;
                veiculo.Combustivel = novoVeiculo.Combustivel;
                veiculo.Cor = novoVeiculo.Cor;
                veiculo.Lugares = novoVeiculo.Lugares;
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        public void RemoverVeiculo(string matricula)
        {
            Veiculo veiculo = ProcurarVeiculoPorMatricula(matricula);
            if (veiculo != null)
            {
                veiculo.Proprietario = null;
                repositorioVeiculos[Hash(matricula)].Remove(veiculo);
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        private int Hash(string matricula)
        {
            return matricula.GetHashCode() % 10;
        }
    }
}