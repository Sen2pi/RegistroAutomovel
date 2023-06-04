using RegistroAutomovel_V1.Repositorio;
using RegistroAutomovel_V1.Modelo;

namespace RegistroAutomovel_V1.Servico
{
   public class ServicoRegistroAutomovel
{
    private RepositorioProprietario repositorioProprietario;
    private RepositorioVeiculo repositorioVeiculo;

    public ServicoRegistroAutomovel()
    {
        repositorioProprietario = new RepositorioProprietario();
        repositorioVeiculo = new RepositorioVeiculo();
    }

    public void ComprarVeiculoNovo(Veiculo veiculo)
    {
        if (veiculo.Proprietario == null)
        {
            repositorioVeiculo.Inserir(veiculo);
            Console.WriteLine("Veículo comprado com sucesso (Novo veículo).");
        }
        else
        {
            Console.WriteLine("O veículo já possui um proprietário.");
        }
    }

    public void ComprarVeiculoSegundaMao(Veiculo veiculo, Proprietario novoProprietario)
    {
        Veiculo veiculoExistente = repositorioVeiculo.Procurar(veiculo.Matricula);
        if (veiculoExistente != null)
        {
            if (veiculoExistente.Proprietario != null)
            {
                Console.WriteLine("O veículo já possui um proprietário.");
            }
            else
            {
                repositorioProprietario.Inserir(novoProprietario);
                veiculoExistente.Proprietario = novoProprietario;
                Console.WriteLine("Veículo comprado com sucesso (Segunda mão).");
            }
        }
        else
        {
            Console.WriteLine("Veículo não registrado no sistema.");
        }
    }

    public List<Proprietario> ProcurarProprietariosPorNome(string nome)
    {
        return repositorioProprietario.ProcurarPorNome(nome);
    }

    public Veiculo ProcurarVeiculoPorMatricula(string matricula)
    {
        return repositorioVeiculo.Procurar(matricula);
    }

    public void RemoverVeiculo(string matricula)
    {
        repositorioVeiculo.Remover(matricula);
        Console.WriteLine("Veículo removido com sucesso.");
    }

    public void RegistrarFalecimentoProprietario(int nif)
    {
        repositorioProprietario.RegistrarFalecimento(nif);
    }
}
}