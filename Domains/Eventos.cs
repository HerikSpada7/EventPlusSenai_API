using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus_API.Domains
{
    /// <summary>
    /// </summary>
    [Table("Eventos")]
    public class Eventos
    {
        /// <summary>
        /// </summary>
        [Key]
        public Guid IdEvento { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do evento obrigatório!")]
        public string? NomeEvento { get; set; }

        /// <summary>
        /// </summary>
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do evento obrigatório!")]
        public string? Descricao { get; set; }

        /// <summary>
        /// </summary>
        //ref.tabela TiposEventos
        public Guid IdTipoEvento { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("IdTipoEvento")]
        public TiposEventos? TiposEvento { get; set; }

        /// <summary>
        /// </summary>
        //ref.tabela Instituicoes
        public Guid IdInstituicao { get; set; }

        /// <summary>
        /// </summary>
        [ForeignKey("IdInstituicao")]
        public Instituicoes? Instituicao { get; set; }

        /// <summary>
        /// </summary>
        public Presencas? Presencas { get; set; }
    }
}