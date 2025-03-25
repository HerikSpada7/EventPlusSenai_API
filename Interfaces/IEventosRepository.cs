using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    public interface IEventosRepository
    {
        void Cadastrar(Eventos evento);
        void Deletar(Guid id);
        List<Eventos> Listar();
        List<Eventos> ListarPorId(Guid id);
        List<Eventos> ProximosEventos();
        Eventos BuscarPorId(Guid id);
        void Atualizar(Guid id, Eventos evento);
    }
}