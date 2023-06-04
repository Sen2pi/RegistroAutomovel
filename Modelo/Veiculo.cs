using System.Text;

namespace RegistroAutomovel_V1.Modelo;

public class Veiculo
{
    public string Matricula { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int AnoConstrucao { get; set; }
    public DateTime DataInicioCirculacao { get; set; }
    public Proprietario Proprietario { get; set; }
    public string Combustivel { get; set; }
    public string Cor { get; set; }
    public int Lugares { get; set; }

    public Veiculo(string matricula, string marca, string modelo, int anoConstrucao, DateTime dataInicioCirculacao, string combustivel, string cor, int lugares)
    {
        Matricula = matricula;
        Marca = marca;
        Modelo = modelo;
        AnoConstrucao = anoConstrucao;
        DataInicioCirculacao = dataInicioCirculacao;
        Combustivel = combustivel;
        Cor = cor;
        Lugares = lugares;
    }
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
        sb.AppendLine("||==============================||");

        return sb.ToString();
    }
}