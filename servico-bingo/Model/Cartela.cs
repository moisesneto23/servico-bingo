using OrcamentoGenerico.Api.Dominio.Entite.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace servico_bingo.Model
{
    public class Cartela
    {
        public Cartela(int id, string nome, string? cPF)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string? CPF { get; set; }
        public virtual ICollection<CartelaNumeroBingo> CartelaNumeroBingos { get; set; }


    }
}
