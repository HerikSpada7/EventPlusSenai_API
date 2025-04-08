using Azure;
using Azure.AI.ContentSafety;
using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
using EventPlus_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;

namespace EventPlus_API.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ComentariosEventoController : ControllerBase
    {
        private readonly IComentariosEventosRepository _comentarioEventoRepository;
        private readonly ContentSafetyClient _contentSafetyClient;

        /// <summary>
        /// </summary>
        public ComentariosEventoController(ContentSafetyClient  contentSafetyClient,IComentariosEventosRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
            _contentSafetyClient = contentSafetyClient;
        }

        /// <summary>
        /// Endpoint para cadastrar novo comentario do evento
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(ComentariosEventos novoComentarioEvento)
        {
            try
            {
                if(string.IsNullOrEmpty(novoComentarioEvento.Descricao))
                {
                    return BadRequest("O texto a ser moderado não pode estar vazio!");
                }

                //criar objeto de análise do content safety
                var request = new AnalyzeTextOptions(novoComentarioEvento.Descricao);

                //chamar a API do content Safety
                Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

                //verificar se o texto analisado tem alguma severidade(termos ofensivos)
                bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 8);

                //se o conteúdo for impróprio, não exibe, caso contrário, exibe
                novoComentarioEvento.Exibe = !temConteudoImproprio;

                //cadastra de fato o comentário
                _comentarioEventoRepository.Cadastrar(novoComentarioEvento);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar o comentario do evento por ID
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Endpoint para buscar o comentario do evento por ID
        /// </summary>
        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetExibe(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.ListarSomenteExibe(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint para listar o comentario do evento por ID
        /// </summary>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint para buscar o comentario do evento por ID
        /// </summary>
        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByIdUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
