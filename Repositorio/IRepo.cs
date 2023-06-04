namespace RegistroAutomovel_V1.Repositorio;

public interface IRepo<T, TKey>
{
    void Adicionar(T item);
    bool Remover(TKey id);
    T Obter(TKey id);
    bool Existe(TKey id);
}