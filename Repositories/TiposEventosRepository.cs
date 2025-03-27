using EventPlus_API.Domains;
using EventPlus_API.Interfaces;

namespace EventPlus_API.Repositories
{
    /// <summary>
    /// Repositório para gerenciamento dos tipos dos eventos
    /// </summary>
    public class TiposEventosRepository : ITiposEventosRepository
    {

        private readonly Contexts.EventosContext _context;

        /// <summary>
        /// Repositório para gerenciamento dos tipos dos eventos
        /// </summary>
        public TiposEventosRepository(Contexts.EventosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos dos eventos
        /// </summary>
        public void Atualizar(Guid id, TiposEventos tipoEvento)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }

                _context.TiposEventos.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos dos eventos
        /// </summary>
        public TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposEventos.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos dos eventos
        /// </summary>
        public void Cadastrar(TiposEventos tipoEvento)
        {
            try
            {
                tipoEvento.IdTipoEvento = Guid.NewGuid();

                _context.TiposEventos.Add(tipoEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos dos eventos
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposEventos.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos dos eventos
        /// </summary>
        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
