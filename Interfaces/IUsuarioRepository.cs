using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IUsuarioRepository
    {

        /// <summary>
        /// </summary>
        void Cadastrar(Usuarios usuario);

        /// <summary>
        /// </summary>
        List<Usuarios> Listar();

        /// <summary>
        /// </summary>
        Usuarios BuscarPorId(Guid id);

        /// <summary>
        /// </summary>
        Usuarios BuscarPorEmailESenha(string email, string senha);
    }
}
