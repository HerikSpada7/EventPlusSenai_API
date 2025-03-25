using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    public interface ITiposUsuariosRepository
    {
        void Cadastrar(TiposUsuarios tipoUsuario);
        void Deletar(Guid id);
        List<TiposUsuarios> Listar();
        TiposUsuarios BuscarPorId(Guid id);
        void Atualizar(Guid id, TiposUsuarios tipoUsuario);
    }
}
