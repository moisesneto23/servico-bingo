using Microsoft.EntityFrameworkCore;
using OrcamentoGenerico.Api.Configuracoes.Contexto;
using servico_bingo.Model;

namespace servico_bingo.Repository
{
    public class CartelaRepository
    {
        protected readonly ContextoConfig _context ;
        public CartelaRepository()
        {
            _context = new ContextoConfig();
        }
        public IEnumerable<Cartela>ObterTodasCartelas()
        {
            var cartelas = _context.Cartela.Include(x=>x.CartelaNumeroBingos).ToList();
       
            return cartelas;
        }

        public int ObterIdCartela()
        {
            try
            {
                return _context.Cartela.Max(x => x.Id);
            }
            catch (Exception)
            {

               return 0;
            }
            
        }
        

        internal void CadastroCartela(Cartela cartela)
        {
            //for (int i = 0; i < 75; i++)
            //{
            //    NumeroBingo nn = new NumeroBingo(i+1);
            //    _context.NumeroBingo.Add(nn);
            //    _context.SaveChanges();
            //}
            var id = _context.Cartela.Add(cartela);
            _context.SaveChanges();
        }

        public string AdicionarNumeroSorteado(int numero, int posicao)
        {
            try
            {
                var numeroSorteio = new NumeroSorteado();
                numeroSorteio.NumeroBingoId = numero;
                numeroSorteio.Posicao = posicao;
                _context.NumeroSorteado.Add(numeroSorteio);
                var data = _context.CartelaNumeroBingo.Where(c=>c.NumeroBingoId == numero).ToList();
                data.ForEach(x => x.Sorteado = true);
                _context.CartelaNumeroBingo.UpdateRange(data);
                _context.SaveChanges();
                if (existeGanhador())
                    return "alguem ganhou!!!";
                return "numero adicionado com sucesso";
            }
            catch (Exception ex)
            {

               return "não foi possivel inserir o numero";
            }
            
            
        }

        public List<Cartela> ObterCartelasPorApelido(string nome)
        {
            return _context.Cartela.Where(ca => ca.Nome.ToLower() == nome.ToLower()).Include(cb => cb.CartelaNumeroBingos).ToList();
        }

        private bool existeGanhador()
        {
            var data = _context.Cartela.Where(ca=>ca.CartelaNumeroBingos.All(x=>x.Sorteado == true)).Include(cb=>cb.CartelaNumeroBingos).ToList();
            return data.Any();
    
        }

        public bool NumeroExiste(int numero)
        {
            return _context.NumeroSorteado.Where(x=>x.NumeroBingoId == numero).Any();
        }
    }
}
