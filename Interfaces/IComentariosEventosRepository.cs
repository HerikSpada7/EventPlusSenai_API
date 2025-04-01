using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IComentariosEventosRepository
    {
        /// <summary>
        /// </summary>
        void Cadastrar(ComentariosEventos comentarioEvento);

        /// <summary>
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// </summary>
        List<ComentariosEventos> Listar(Guid id);

        /// <summary>
        /// </summary>
        ComentariosEventos BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);

        /// <summary>
        /// </summary>
        List<ComentariosEventos> ListarSomenteExibe(Guid id);
    }
}
