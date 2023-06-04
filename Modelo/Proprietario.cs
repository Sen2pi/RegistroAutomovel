using System.Text;

namespace RegistroAutomovel_V1.Modelo;

public class Proprietario
{
    public int NIF { get; set; }
    public string NomeCompleto { get; set; }
    public string NumeroContacto { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Falecido { get; set; }

    public Veiculo[] Vehiculos;

    public Proprietario(int nif, string nomeCompleto, string numeroContacto, DateTime dataNascimento)
    {
        NIF = nif;
        NomeCompleto = nomeCompleto;
        NumeroContacto = numeroContacto;
        DataNascimento = dataNascimento;
        Falecido = false;
        Vehiculos = new Veiculo[3];
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("||==============================||");
        sb.AppendLine("||         Proprietário         ||");
        sb.AppendLine("||==============================||");
        sb.AppendLine($" NIF: {NIF,-30} ");
        sb.AppendLine($" Nome Completo: {NomeCompleto,-30} ");
        sb.AppendLine($" Número de Contato: {NumeroContacto,-30} ");
        sb.AppendLine($" Data de Nascimento: {DataNascimento.ToString("dd/MM/yyyy"),-30} ");
        sb.AppendLine($" Falecido: {(Falecido ? "Sim" : "Não"),-30} ");
        if (Vehiculos[0] != null) sb.AppendLine($" Veiculo: {Vehiculos[0].Modelo} Matricula: {Vehiculos[0].Matricula}");
        if (Vehiculos[1] != null) sb.AppendLine($" Veiculo: {Vehiculos[1].Modelo} Matricula: {Vehiculos[1].Matricula}");
        if (Vehiculos[2] != null) sb.AppendLine($" Veiculo: {Vehiculos[2].Modelo} Matricula: {Vehiculos[2].Matricula}");
        return sb.ToString();
    }
}