using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("ComentariosEventos")]
    public class ComentariosEventos
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdComentarioEvento { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Descrição do comentário obrigatório!")]
        public string? Descricao { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "BIT")]
        [Required]
        public bool Exibe { get; set; }

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
