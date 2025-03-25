using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    public interface ITiposEventosRepository
    {
        void Cadastrar(TiposEventos tipoEvento);
        void Deletar(Guid id);
        List<TiposEventos> Listar();
        TiposEventos BuscarPorId(Guid id);
        void Atualizar(Guid id, TiposEventos tipoEvento);
    }
}
