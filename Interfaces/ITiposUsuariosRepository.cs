using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    /// <summary>
    /// </summary>
    public interface ITiposUsuariosRepository
    {
        /// <summary>
        /// </summary>
        void Cadastrar(TiposUsuarios tipoUsuario);

        /// <summary>
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// </summary>
        List<TiposUsuarios> Listar();

        /// <summary>
        /// </summary>
        TiposUsuarios BuscarPorId(Guid id);

        /// <summary>
        /// </summary>
        void Atualizar(Guid id, TiposUsuarios tipoUsuario);
    }
}
