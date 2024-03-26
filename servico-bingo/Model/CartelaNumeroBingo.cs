using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace servico_bingo.Model
{
    public class CartelaNumeroBingo
    {
        public CartelaNumeroBingo(int cartelaId, int numeroBingoId)
        {
            CartelaId = cartelaId;
            NumeroBingoId = numeroBingoId;
            Sorteado = false;
        }

        public int CartelaId { get; set; }
        [JsonIgnore]
        public virtual Cartela Cartela { get; set; }
        public int NumeroBingoId { get; set; }
        [JsonIgnore]
        public virtual NumeroBingo NumeroBingo { get; set; }
        public bool Sorteado { get; set; }
    }
}
