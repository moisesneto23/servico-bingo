using System.ComponentModel.DataAnnotations;

namespace servico_bingo.Model
{
    public class NumeroSorteado
    {
        public int NumeroBingoId { get; set; }
        public int Posicao { get; set; }
        public virtual NumeroBingo NumeroBingo { get; set; }
    }
}
