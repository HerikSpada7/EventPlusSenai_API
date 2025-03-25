using EventPlus_API.Domains;

namespace EventPlus_API.Interfaces
{
    public interface IPresencasRepository
    {
        void Deletar(Guid id);
        List<Presencas> Listar();
        Presencas BuscarPorId(Guid id);
        void Atualizar(Guid id, Presencas presencaEvento);
        List<Presencas> ListarMinhas(Guid id);
        void Inscrever(Presencas inscricao);
    }
}
