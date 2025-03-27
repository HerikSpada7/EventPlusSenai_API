using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdTipoUsuario { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Tipo do usuário obrigatório!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
