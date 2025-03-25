using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        Usuarios BuscarPorId(Guid id);

        Usuarios BuscarPorEmailESenha(string email, string senha);
    }
}
