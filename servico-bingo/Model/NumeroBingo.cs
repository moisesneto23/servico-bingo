using System.ComponentModel.DataAnnotations;

namespace servico_bingo.Model
{
    public class NumeroBingo
    {
        public NumeroBingo(int numero, ICollection<CartelaNumeroBingo> cartelaNumeroBingos)
        {
            Numero = numero;
            CartelaNumeroBingos = cartelaNumeroBingos;
        }
        public NumeroBingo(int numero)
        {
            Numero = numero;
        }

        public int Numero { get; set; }
        public virtual ICollection<CartelaNumeroBingo> CartelaNumeroBingos { get; set; }
        public virtual NumeroSorteado NumeroSorteado { get; set; }
    }
}
