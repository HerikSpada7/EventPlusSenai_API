using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
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
        public IActionResult Post(Presencas presencaRepository)
        {
            try
            {
                _presencaRepository.Inscrever(presencaRepository);
                return Created();
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
                Presencas novaPresenca = _presencaRepository.BuscarPorId(id);
                return Ok(novaPresenca);
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
        public IActionResult Put(Guid id, Presencas presenca)
        {
            try
            {
                _presencaRepository.Atualizar(id, presenca);
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
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                List<Presencas> listaPresencas = _presencaRepository.Listar();
                return Ok(listaPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das minhas presenças
        /// </summary>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Presencas> listaMinhasPresencas = _presencaRepository.ListarMinhas(id);
                return Ok(listaMinhasPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
}
