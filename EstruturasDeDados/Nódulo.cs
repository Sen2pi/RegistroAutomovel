namespace RegistroAutomovel_V1.EstruturasDeDados;

public class Nódulo<T>
{
    public T Data { get; set; }
    public Nódulo<T> Proximo { get; set; }
    public Nódulo<T> Anterior { get; set; }

    public Nódulo(T data)
    {
        Data = data;
        Proximo = null;
        Anterior = null;
    }
}