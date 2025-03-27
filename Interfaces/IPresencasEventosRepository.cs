using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IPresencasRepository
    {

        /// <summary>
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// </summary>
        List<Presencas> Listar();

        /// <summary>
        /// </summary>
        Presencas BuscarPorId(Guid id);

        /// <summary>
        /// </summary>
        void Atualizar(Guid id, Presencas presencaEvento);

        /// <summary>
        /// </summary>
        List<Presencas> ListarMinhas(Guid id);

        /// <summary>
        /// </summary>
        void Inscrever(Presencas inscricao);
    }
}
