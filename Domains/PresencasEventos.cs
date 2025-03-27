using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("Presencas")]
    public class Presencas
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdPresencaEvento { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação obrigatório!")]
        public bool Situacao { get; set; }

        /// <summary>
        /// </summary>
        //ref.tabela Usuario
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("IdUsuario")]
        public Usuarios? Usuario { get; set; }

        /// <summary>
        /// </summary>
        //ref.tabela Evento
        [Required(ErrorMessage = "Evento obrigatório!")]
        public Guid IdEvento { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("IdEvento")]
        public Eventos? Evento { get; set; }
    }
}
