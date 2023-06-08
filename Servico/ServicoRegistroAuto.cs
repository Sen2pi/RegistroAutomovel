using RegistroAutomovel_V1.Modelo;
using RegistroAutomovel_V1.Repositorio;
namespace RegistroAutomovel_V1.Servico
{
    public class ServicoRegistroAuto
    {
        public  ProprietarioRepositorio proprietarioRepositorio;
        public  VeiculoRepositorio veiculoRepositorio;
        
        // Construtor class
        public ServicoRegistroAuto()
        {
            proprietarioRepositorio = new ProprietarioRepositorio();
            veiculoRepositorio = new VeiculoRepositorio();
        }
        
        // Registrar Proprietario
        public void RegistrarProprietario(int nif, string nomeCompleto, string numeroContacto, DateTime dataNascimento)
        {
            if (proprietarioRepositorio.Existe(nif))
            {
                throw new ArgumentException("Já existe um proprietário registrado com o mesmo NIF.");
            }
            Proprietario proprietario = new Proprietario(nif, nomeCompleto, numeroContacto, dataNascimento);
            proprietarioRepositorio.Adicionar(proprietario);
        }
        
        //Procura Proprietario por nome 
        public List<Proprietario> EncontrarProprietarioPorNome(string nome)
        {
            List<Proprietario> proprietariosEncontrados = new List<Proprietario>();

            foreach (Proprietario proprietario in proprietarioRepositorio.ObterTodos())
            {
                if (proprietario.NomeCompleto.Contains(nome, StringComparison.OrdinalIgnoreCase))
                {
                    proprietariosEncontrados.Add(proprietario);
                }
            }

            return proprietariosEncontrados;
        }
        
        //Registrar Veiculo
        public void RegistrarVeiculo(string matricula, string marca, string modelo, int anoConstrucao, DateTime dataInicioCirculacao, string combustivel, string cor, int lugares)
        {

            try
            {
                Veiculo veiculo = new Veiculo(matricula, marca, modelo, anoConstrucao, dataInicioCirculacao, combustivel, cor, lugares);
                veiculoRepositorio.Adicionar(veiculo);
            }
            catch ( System.NullReferenceException ) { }
            
        }
        
        //Comprar veiculo novo 
        public void ComprarVeiculoNovo(int nifProprietario, Veiculo veiculo)
        {   
            Proprietario proprietario = proprietarioRepositorio.Obter(nifProprietario);

            if (proprietario != null && !proprietario.Falecido)
            {
                veiculo.Proprietario = proprietario;
                if (!veiculoRepositorio.Existe(veiculo.Matricula))
                {
                    veiculoRepositorio.Adicionar(veiculo);
                }
                for (int i = 0; i < proprietario.Vehiculos.Length; i++)
                {
                    if (proprietario.Vehiculos[i] == null)
                    {
                        proprietario.Vehiculos[i] = veiculo;
                        break;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Não é possível realizar a compra. O proprietário não existe ou é falecido.");
            }
        }
        
        //Comprar Vehiculo Em Segunda Mão
        public void ComprarVeiculoEmSegundaMao(int nifComprador, Veiculo veiculo)
        {
            Proprietario comprador = proprietarioRepositorio.Obter(nifComprador);

            if (comprador != null && !comprador.Falecido)
            {
                Proprietario proprietarioAtual = proprietarioRepositorio.Obter(veiculo.Proprietario.NIF);

                if (proprietarioAtual == null || (proprietarioAtual != null && !proprietarioAtual.Falecido))
                {
                    veiculo.Proprietario = comprador;

                    for (int i = 0; i < proprietarioAtual.Vehiculos.Length; i++)
                    {
                        if (proprietarioAtual.Vehiculos[i]?.Matricula == veiculo.Matricula)
                        {
                            proprietarioAtual.Vehiculos[i] = null;
                            break; // Saia do loop após encontrar o veículo
                        }
                    }

                    for (int i = 0; i < comprador.Vehiculos.Length; i++)
                    {
                        if (comprador.Vehiculos[i] == null)
                        {
                            comprador.Vehiculos[i] = veiculo;
                            break; // Saia do loop após atribuir o veículo
                        }
                    }

                    if (!veiculoRepositorio.Existe(veiculo.Matricula))
                    {
                        veiculoRepositorio.Adicionar(veiculo);
                    }
                }
                else
                {
                    throw new InvalidOperationException("Não é possível realizar a compra. O veículo pertence a um proprietário falecido.");
                }
            }
        }

        //Registrar Obito 
        public void RegistrarFalecimentoProprietario(int nif)
        {
            if (!proprietarioRepositorio.Existe(nif))
            {
                throw new ArgumentException("Não existe um proprietário registrado com o NIF especificado.");
            }

            Proprietario proprietario = proprietarioRepositorio.Obter(nif);
            proprietario.Falecido = true;

            // Remover os veículos do proprietário falecido
            for(int i = 0 ; i < proprietario.Vehiculos.Length ;i++)
            {
                if (proprietario.Vehiculos[i] != null)
                {
                    RemoverVeiculo(proprietario.Vehiculos[i].Matricula);
                }
            }
        }
       
        // Remover Propritario
        public bool RemoverProprietario(int nif)
        {
            return proprietarioRepositorio.Remover(nif);
        }
        
        // Remover Veiculo
        public bool RemoverVeiculo(string matricula)
        {
            return veiculoRepositorio.Remover(matricula);
        }
        
        //Obter Proprietario
        public Proprietario ObterProprietario(int nif)
        {
            return proprietarioRepositorio.Obter(nif);
        }
        
        public List<Proprietario> ObterTodosProprietarios()
        {
            return proprietarioRepositorio.ObterTodos();
        }

        //Obter Veiculo
        public Veiculo ObterVeiculo(string matricula)
        {
            return veiculoRepositorio.Obter(matricula);
        }
        
        
        public Veiculo[] ObterTodosVeiculos()
        {
            return veiculoRepositorio.ObterTodos();
        }
        
        //Verificar se proprietario existe 
        public bool ExisteProprietario(int nif)
        {
            return proprietarioRepositorio.Existe(nif);
        }
        
        // Verificar se Veiculo existe
        public bool ExisteVeiculo(string matricula)
        {
            return veiculoRepositorio.Existe(matricula);
        }
        
        //Procurar vehiculo por Modelo 
        public List<Veiculo> EncontrarVeiculosPorModelo(string model)
        {
            List<Veiculo> veiculosEncontrados = new List<Veiculo>();
          
                foreach (Veiculo vh in veiculoRepositorio.ObterTodos())
                {
                    if (vh.Modelo.Equals(model))
                    {
                        veiculosEncontrados.Add(vh);
                    }
                }
                return veiculosEncontrados;
        }
        
        
    }
}