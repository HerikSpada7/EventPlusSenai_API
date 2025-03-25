using EventPlus_API.Domains;
using EventPlus_API.Interfaces;

namespace EventPlus_API.Repositories
{
    public class ComentariosEventosRepository : IComentariosEventosRepository
    {

        private readonly Contexts.EventosContext _context;

        public ComentariosEventosRepository(Contexts.EventosContext context)
        {
            _context = context;
        }
        public ComentariosEventos BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentariosEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuarios
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Eventos
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentariosEventos comentarioEvento)
        {
            try
            {
                comentarioEvento.IdComentarioEvento = Guid.NewGuid();

                _context.ComentariosEventos.Add(comentarioEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ComentariosEventos comentarioEventoBuscado = _context.ComentariosEventos.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEventos.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentariosEventos> Listar(Guid id)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentariosEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuarios
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Eventos
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentariosEventos> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentariosEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuarios
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Eventos
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}