using System.Text;

namespace RegistroAutomovel_V1.Modelo;

public class Veiculo
{
    private string matricula;
    private string marca;
    private string modelo;
    private int anoConstrucao;
    private DateTime dataInicioCirculacao;
    private Proprietario proprietario;
    private string combustivel;
    private string cor;
    private int lugares;

    public Veiculo(string matricula, string marca, string modelo, int anoConstrucao, DateTime dataInicioCirculacao, string combustivel, string cor, int lugares)
    {
        this.matricula = matricula;
        this.marca = marca;
        this.modelo = modelo;
        this.anoConstrucao = anoConstrucao;
        this.dataInicioCirculacao = dataInicioCirculacao;
        this.combustivel = combustivel;
        this.cor = cor;
        this.lugares = lugares;
    }
    
    internal string Matricula { get => matricula; set => matricula = value; }
    internal string Marca { get=> marca; set => marca = value; }
    internal string Modelo { get => modelo; set => modelo = value; }
    internal int AnoConstrucao { get=> anoConstrucao; set=> anoConstrucao = value; }
    internal DateTime DataInicioCirculacao { get=> dataInicioCirculacao; set=> dataInicioCirculacao = value; }
    internal Proprietario Proprietario { get=> proprietario; set=> proprietario = value; }
    internal string Combustivel { get => combustivel; set=> combustivel = value; }
    internal string Cor { get => cor; set => cor = value; }
    internal int Lugares { get=> lugares; set=> lugares = value; }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("||==============================||");
        sb.AppendLine("||             Veiculo          ||");
        sb.AppendLine("||==============================||");
        sb.AppendLine($" Matrícula: {Matricula,-15} ");
        sb.AppendLine($" Marca: {Marca,-20} ");
        sb.AppendLine($" Modelo: {Modelo,-19} ");
        sb.AppendLine($" Ano de Construção: {AnoConstrucao,-10} ");
        sb.AppendLine($" Data de Início de Circulação: {DataInicioCirculacao.ToString("dd/MM/yyyy"),-23} ");
        sb.AppendLine($" Proprietário: { Proprietario.NomeCompleto,-18}{Proprietario.NIF, -28} ");
        sb.AppendLine($" Combustível: {Combustivel,-16} ");
        sb.AppendLine($" Cor: {Cor,-22} ");
        sb.AppendLine($" Lugares: {Lugares,-19} ");

        return sb.ToString();
    }
}