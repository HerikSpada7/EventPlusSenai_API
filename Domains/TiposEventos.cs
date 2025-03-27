using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("TiposEventos")]
    public class TiposEventos
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdTipoEvento { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatório!")]
        public string? TituloTipoEvento { get; set; }
    }
}
