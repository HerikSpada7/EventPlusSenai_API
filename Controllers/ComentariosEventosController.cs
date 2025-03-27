using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        private readonly IComentariosEventosRepository _comentarioEventoRepository;

        public ComentariosEventoController(IComentariosEventosRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo comentario do evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(ComentariosEventos novoComentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentarioEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar novo comentario do evento
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar comentarios do evento
        /// </summary>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por id o comentario do usuario do evento
        /// </summary>
        [HttpGet("BuscarPorIdUsuario/{UsuarioID},{EventoID}")]
        public IActionResult GetById(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                ComentariosEventos novoComentarioEvento = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioID, EventoID);
                return Ok(novoComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
