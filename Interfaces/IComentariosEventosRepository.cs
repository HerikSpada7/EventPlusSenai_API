using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    public interface IComentariosEventosRepository
    {
        void Cadastrar(ComentariosEventos comentarioEvento);
        void Deletar(Guid id);
        List<ComentariosEventos> Listar(Guid id);
        ComentariosEventos BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    }
}
