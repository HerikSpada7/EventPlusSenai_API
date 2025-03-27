using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("Instituicoes")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicoes
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdInstituicao { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "Cnpj obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço obrigatório!")]
        public string? Endereco { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome Fantasia obrigatório!")]
        public string? NomeFantasia { get; set; }
    }
}
