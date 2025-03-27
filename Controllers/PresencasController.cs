using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
using EventPlus_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasController : ControllerBase
    {
        private readonly IPresencasRepository _presencaRepository;

        public PresencasController(IPresencasRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(Presencas presencaEvento)
        {
            try
            {
                _presencaRepository.Inscrever(presencaEvento);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// Endpoint para deletar a presença
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por Id a presença
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_presencaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar as presenças
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Presencas presencas)
        {
            try
            {
                _presencaRepository.Atualizar(id, presencas);

                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das presenças
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das minhas presenças
        /// </summary>
        [HttpGet("ListarMinhas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_presencaRepository.ListarMinhas(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
