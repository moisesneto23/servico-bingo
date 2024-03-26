using servico_bingo.Model;
using servico_bingo.Repository;

namespace servico_bingo.Service
{

    public class GeracaoCartelaService
    {
        private readonly CartelaRepository _repository;
        public GeracaoCartelaService()
        {
            _repository = new CartelaRepository();
        }

        public Cartela gerarCartela(string apelido)
        {
            do
            {
                GeraNumero();
            } while (CartelaExiste(this.numeros));


            int idCartela = _repository.ObterIdCartela() +1;
            
            TabelaBingo tabela = new TabelaBingo();
            Cartela cartela = new Cartela(idCartela, apelido,null);
            cartela.CartelaNumeroBingos = new List<CartelaNumeroBingo>();
            foreach (var numero in numeros)
            {
                var cartelaCartela = new CartelaNumeroBingo(idCartela,numero);
                cartela.CartelaNumeroBingos.Add(cartelaCartela);
            }

            _repository.CadastroCartela(cartela);
            return cartela;
        }

        public string AdicionarNumeroSorteado(int numero, int posicao)
        {
            if (!verificaNumeroExisteNumero(numero))
                return _repository.AdicionarNumeroSorteado(numero, posicao);
            return "escolha outro numero pois esse ja foi inserido";
        }

        private bool verificaNumeroExisteNumero(int numero)
        {
            return _repository.NumeroExiste(numero);
        }

        private bool CartelaExiste(List<int> numeros)
        {
            var cartelas = _repository.ObterTodasCartelas();
            foreach (var cartela in cartelas)
            {
                var numerosCartela = cartela.CartelaNumeroBingos.Select(x => x.NumeroBingoId).ToList();
                var numerosCartelaHashSet = new HashSet<int>(numerosCartela);
                var numerosHashSet = new HashSet<int>(numeros);
                if (numerosCartelaHashSet.SetEquals(numerosHashSet))
                    return true;
            }
            return false;
        }
        private List<int> numeros { get; set; } = new List<int>();
        private Random random = new Random();
        private void GeraNumero()
        {

            while (numeros.Count < 24)
            {
                int num = random.Next(1, 75);
                if (numeros.Contains(num))
                    GeraNumero();
                else numeros.Add(num);
            }
        }

    }
}
