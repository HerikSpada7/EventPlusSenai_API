using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosRepository _eventoRepository;

        public EventosController(IEventosRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(Eventos eventoRepository)
        {
            try
            {
                _eventoRepository.Cadastrar(eventoRepository);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.Listar();
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarPorId/{id}")]
        public IActionResult ListarPorId(Guid id)
        {
            try
            {
                List<Eventos> listaEventos = _eventoRepository.ListarPorId(id);
                return Ok(listaEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.ProximosEventos();
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Eventos novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
}
