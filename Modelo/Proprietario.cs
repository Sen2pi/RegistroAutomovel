using System.Text;

namespace RegistroAutomovel_V1.Modelo;

public class Proprietario
{

    private int nif;
    private string nomeCompleto;
    private string numeroContacto;
    private DateTime dataNascimento;
    private bool falecido;  
    
    public Veiculo[] Vehiculos;

    public Proprietario(int nif, string nomeCompleto, string numeroContacto, DateTime dataNascimento)
    {
        this.nif = nif;
        this.nomeCompleto = nomeCompleto;
        this.numeroContacto = numeroContacto;
        this.dataNascimento = dataNascimento;
        this.falecido = false;
        Vehiculos = new Veiculo[3];
    }
    internal int NIF { get => nif; set => nif = value; }
    internal string NomeCompleto { get => nomeCompleto; set => nomeCompleto = value; }
    internal string NumeroContacto { get => numeroContacto; set => numeroContacto = value; }
    internal DateTime DataNascimento { get => dataNascimento; set => dataNascimento = value; }
    internal bool Falecido { get => falecido; set => falecido = value; }

    
    
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