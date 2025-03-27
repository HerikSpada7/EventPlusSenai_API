using System.ComponentModel.DataAnnotations;

namespace EventPlus_API.DTO
{
    /// <summary>
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// </summary>
        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        public string? email { get; set; }

        /// <summary>
        /// </summary>
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string? senha { get; set; }
    }
}
