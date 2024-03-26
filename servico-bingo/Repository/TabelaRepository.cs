using Microsoft.EntityFrameworkCore;
using OrcamentoGenerico.Api.Configuracoes.Contexto;
using servico_bingo.Model;
using System.Runtime.CompilerServices;

namespace servico_bingo.Repository
{
    public class TabelaRepository
    {
        protected readonly ContextoConfig _context;
        public TabelaRepository(ContextoConfig contexto)
        {
            _context = contexto;
        }

        public bool AdicionarTabela(TabelaBingo tabela) { return true; }
        //public List<TabelaBingo> obterToadasTabelas () {
        //    // return _context.TabelaBingo.ToList();
        //    return true;
        //}
        public int AdicionarBola(int numero,int posicao)
        {
   
                        string sql = @"UPDATE TabelaBingo SET primeiroAtivo = true where 
primeiro = @numero ||
 Segundo= @numero ||
          Terceiro    = @numero ||                                       
Quarto = @numero ||
Quinto = @numero ||
Sexto = @numero ||
Setimo = @numero ||
Oitavo = @numero ||
Nono = @numero ||
Decimo = @numero ||
DecimoPrimeiro = @numero ||
DecimoSegundo = @numero ||
DecimoTerceiro = @numero ||
DecimoQuarto = @numero ||
DecimoQuinto = @numero ||
DecimoSexto = @numero ||
DecimoSetimo = @numero ||
DecimoOitavo = @numero ||
DecimoNono = @numero ||
Vigezimo = @numero ||
VigezimoPrimeiro = @numero ||
VigezimoSegundo = @numero ||
VigezimoTerceiro =  = @numero ||
VigezimoQuarto =  = @numero
";

            FormattableString sqll = FormattableStringFactory.Create($"SELECT * FROM Tabela WHERE Nome = {""}");
            // string sql = "UPDATE TabelaBingo SET Nome = @NovoNome WHERE Id = @ProdutoId";
            _context.Database.ExecuteSql(sqll);
            return 1;
     
        }
        public int verificarGanhador()
        {
            return 0;
        }
        private string selecionaPosicao(int posicao)
        {
            return "";
        }
    }
}
