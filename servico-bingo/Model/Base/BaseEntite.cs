

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrcamentoGenerico.Api.Dominio.Entite.Base
{
    public abstract class BaseEntite
    {
        [Key]
        public int Id { get; set; }
        //[NotMapped]
        //private DateTime? _criado;
        //[NotMapped]
        //public DateTime? DataCriacao
        //{
        //    get { return _criado; }
        //    set { _criado = (value == null ? DateTime.UtcNow : value); }
        //}
        //[NotMapped]
        //public DateTime? DataModificacao { get; set; }
        //[NotMapped]
        //public string? UsuarioModificacaoLog { get; set; }
    }
}
