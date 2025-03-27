using EventPlus_API.Domains;
using EventPlus_API.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EventPlus_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para Buscar um Login pelo seu id
        /// </summary>
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.email!, loginDTO.senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválida!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim("Tipo do usuário", usuarioBuscado.TipoUsuario!.TituloTipoUsuario!),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventos-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "EventPlus_API",

                    audience: "EventPlus_API",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds
                );

                return Ok
                (
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                    }
                );
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
