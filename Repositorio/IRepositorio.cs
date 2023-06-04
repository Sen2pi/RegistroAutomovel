namespace RegistroAutomovel_V1.Repositorio
{
    public interface IRepositorio<T, TKey>
    {
        void Inserir(T elemento);
        T Procurar(TKey chave);
        void Editar(TKey chave, T novoElemento);
        void Remover(TKey chave);
    }
    
}