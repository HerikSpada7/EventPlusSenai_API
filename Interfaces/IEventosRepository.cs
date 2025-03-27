using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IEventosRepository
    {
        /// <summary>
        /// </summary>
        void Cadastrar(Eventos evento);

        /// <summary>
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// </summary>
        List<Eventos> Listar();

        /// <summary>
        /// </summary>
        List<Eventos> ListarPorId(Guid id);

        /// <summary>
        /// </summary>
        List<Eventos> ProximosEventos();

        /// <summary>
        /// </summary>
        Eventos BuscarPorId(Guid id);

        /// <summary>
        /// </summary>
        void Atualizar(Guid id, Eventos evento);
    }
}