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
        private readonly IEventosRepository _eventosRepository;
        public EventosController(IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
        }

        /// <summary>
        /// Endpoint para listar os eventos
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventosRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar por ID um evento utilizando a presença
        /// </summary>
        [HttpGet("ListarPorId")]
        public IActionResult ListById(Guid id)
        {
            try
            {
                return Ok(_eventosRepository.ListarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para listar eventos proximos da data atual
        /// </summary>
        [HttpGet("ListarProximos")]
        public IActionResult GetNextEvents()
        {
            try
            {
                return Ok(_eventosRepository.ProximosEventos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por ID um evento
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventosRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para cadastrar eventos
        /// </summary>
        [HttpPost]
        public IActionResult Post(Eventos evento)
        {
            try
            {
                _eventosRepository.Cadastrar(evento);


                return StatusCode(201, evento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar um evento
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Eventos evento)
        {
            try
            {
                _eventosRepository.Atualizar(id, evento);

                return StatusCode(204, evento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar um evento
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventosRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
