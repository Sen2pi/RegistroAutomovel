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
    
    public Veiculo[] ObterTodos()
    {
        KeyValuePair<string, Veiculo>[] veiculos = veiculoTable.ObterTodos();
        Veiculo[] resultado = new Veiculo[veiculos.Length];

        for (int i = 0; i < veiculos.Length; i++)
        {
            resultado[i] = veiculos[i].Value;
        }

        return resultado;
    }

    public Veiculo Obter(string matricula)
    {
        return veiculoTable.Obter(matricula);
    }
    

    public bool Existe(string matricula)
    {
        return veiculoTable.Contem(matricula);
    }
}
