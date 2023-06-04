using RegistroAutomovel_V1.EstruturasDeDados;
using RegistroAutomovel_V1.Modelo;

namespace RegistroAutomovel_V1.Repositorio;

public class VeiculoRepositorio : IRepo<Veiculo, string>
{
    private MyHashTable<string, Veiculo> veiculoTable;

    public VeiculoRepositorio()
    {
        veiculoTable = new MyHashTable<string, Veiculo>();
    }

    public void Adicionar(Veiculo veiculo)
    {
        veiculoTable.Adicionar(veiculo.Matricula, veiculo);
    }
    

    public bool Remover(string matricula)
    {
        return veiculoTable.Remover(matricula);
    }
    
    public List<Veiculo> ObterTodos()
    {
        List<Veiculo> novaLista = new List<Veiculo>();
        foreach (KeyValuePair<string, Veiculo> veiculo in veiculoTable.ObterTodos())
        {
            novaLista.Add(veiculo.Value);
        }
        return novaLista;
    }

    public Veiculo Obter(string matricula)
    {
        return veiculoTable.Obter(matricula);
    }
    

    public bool Existe(string matricula)
    {
        return veiculoTable.ContainsKey(matricula);
    }
}
