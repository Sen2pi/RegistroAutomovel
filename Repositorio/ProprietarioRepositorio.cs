using RegistroAutomovel_V1.EstruturasDeDados;
using RegistroAutomovel_V1.Modelo;

namespace RegistroAutomovel_V1.Repositorio;

public class ProprietarioRepositorio : IRepo<Proprietario, int>
{
    
    private MyLinkedList<Proprietario> proprietarioList;

    public ProprietarioRepositorio()
    {
        proprietarioList = new EstruturasDeDados.MyLinkedList<Proprietario>();
    }
    public List<Proprietario> ObterTodos()
    {
        List<Proprietario> listaProprietarios = new List<Proprietario>();

        foreach (Proprietario proprietario in proprietarioList)
        {
            proprietario.ToString();
            listaProprietarios.Add(proprietario);
        }
        
        return listaProprietarios;
    }

    public void Adicionar(Proprietario proprietario)
    {
        proprietarioList.AdicionarFinal(proprietario);
    }

    public bool Remover(int nif)
    {
        return proprietarioList.Remover(proprietario => proprietario.NIF == nif);
    }

    public Proprietario Obter(int nif)
    {
        return proprietarioList.Obter(proprietario => proprietario.NIF == nif);
    }
    
    public Proprietario ObterNome(string nome)
    {
        return proprietarioList.Obter(proprietario => proprietario.NomeCompleto == nome);
    }

    public bool Existe(int nif)
    {
        return proprietarioList.Contem(proprietario => proprietario.NIF == nif);
    }
}