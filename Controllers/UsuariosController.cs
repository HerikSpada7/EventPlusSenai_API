using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo usuario
        /// </summary>
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201, novoUsuario);

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }


        }

        /// <summary>
        /// Endpoint para buscar usuario por Id
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuarios novoUsuario = _usuarioRepository.BuscarPorId(id);
                return Ok(novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorEmailESenha/{email}, {senha}")]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuarios novoUsuario = _usuarioRepository.BuscarPorEmailESenha(email, senha);
                return Ok(novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
}
