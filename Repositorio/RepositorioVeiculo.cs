using RegistroAutomovel_V1.Modelo;

namespace RegistroAutomovel_V1.Repositorio
{
    public class RepositorioVeiculo : IRepositorio<Veiculo, string>
    {   
        private Dictionary<int, List<Veiculo>> repositorio;

        public RepositorioVeiculo()
        {
            repositorio = new Dictionary<int, List<Veiculo>>();
            for (int i = 0; i < 10; i++)
            {
                repositorio.Add(i, new List<Veiculo>());
            }
        }

        public void Inserir(Veiculo veiculo)
        {
            if (Procurar(veiculo.Matricula) == null)
            {
                repositorio[Hash(veiculo.Matricula)].Add(veiculo);
            }
            else
            {
                Console.WriteLine("Veículo com a mesma matrícula já existe.");
            }
        }

        public Veiculo Procurar(string matricula)
        {
            foreach (var listaColisao in repositorio[Hash(matricula)])
            {
                if (listaColisao.Matricula == matricula)
                {
                    return listaColisao;
                }
            }
            return null;
        }

        public void Editar(string matricula, Veiculo novoVeiculo)
        {
            Veiculo veiculo = Procurar(matricula);
            if (veiculo != null)
            {
                veiculo.Marca = novoVeiculo.Marca;
                veiculo.Modelo = novoVeiculo.Modelo;
                veiculo.AnoConstrucao = novoVeiculo.AnoConstrucao;
                veiculo.DataInicioCirculacao = novoVeiculo.DataInicioCirculacao;
                veiculo.Proprietario = novoVeiculo.Proprietario;
                veiculo.Combustivel = novoVeiculo.Combustivel;
                veiculo.Cor = novoVeiculo.Cor;
                veiculo.Lugares = novoVeiculo.Lugares;
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        public void Remover(string matricula)
        {
            Veiculo veiculo = Procurar(matricula);
            if (veiculo != null)
            {
                veiculo.Proprietario = null;
                repositorio[Hash(matricula)].Remove(veiculo);
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
        }

        private int Hash(string matricula)
        {
            return matricula.GetHashCode() % 10;
        }

    }
}