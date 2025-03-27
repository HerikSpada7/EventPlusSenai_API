using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuarios
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do usuário é obrigatório!")]
        public string? Nome{ get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email do usuário é obrigatório!")]
        public string? Email { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string? Senha { get; set; }

        /// <summary>
        /// </summary>
        //referência para a entidade TiposUsuarios
        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("IdTipoUsuario")]
        public TiposUsuarios? TipoUsuario { get; set; }
    }
}
