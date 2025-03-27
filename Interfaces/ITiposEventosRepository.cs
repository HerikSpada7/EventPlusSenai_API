using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    /// <summary>
    /// </summary>
    public interface ITiposEventosRepository
    {

        /// <summary>
        /// </summary>
        void Cadastrar(TiposEventos tipoEvento);

        /// <summary>
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// </summary>
        List<TiposEventos> Listar();

        /// <summary>
        /// </summary>
        TiposEventos BuscarPorId(Guid id);

        /// <summary>
        /// </summary>
        void Atualizar(Guid id, TiposEventos tipoEvento);
    }
}
