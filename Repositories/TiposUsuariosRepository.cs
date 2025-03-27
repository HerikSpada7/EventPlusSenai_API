using EventPlus_API.Contexts;
using EventPlus_API.Domains;
using EventPlus_API.Interfaces;

namespace EventPlus_API.Repositories
{
    namespace webapi.event_.Repositories
    {
        /// <summary>
        /// Repositório para gerenciamento dos tipos dos usuario.
        /// </summary>
        public class TiposUsuariosRepository : ITiposUsuariosRepository
        {
            private readonly EventosContext _context;

            /// <summary>
            /// Repositório para gerenciamento dos tipos dos usuario.
            /// </summary>
            public TiposUsuariosRepository(EventosContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Repositório para gerenciamento dos tipos dos usuario.
            /// </summary>
            public void Atualizar(Guid id, TiposUsuarios tipoUsuario)
            {
                try
                {
                    TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(id)!;

                    if (tipoBuscado != null)
                    {
                        tipoBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                    }

                    _context.TiposUsuarios.Update(tipoBuscado!);

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            /// <summary>
            /// Repositório para gerenciamento dos tipos dos usuario.
            /// </summary>
            public TiposUsuarios BuscarPorId(Guid id)
            {
                try
                {
                    return _context.TiposUsuarios.Find(id)!;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            /// <summary>
            /// Repositório para gerenciamento dos tipos dos usuario.
            /// </summary>
            public void Cadastrar(TiposUsuarios tipoUsuario)
            {
                try
                {
                    tipoUsuario.IdTipoUsuario = Guid.NewGuid();

                    _context.TiposUsuarios.Add(tipoUsuario);

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            /// <summary>
            /// Repositório para gerenciamento dos tipos dos usuario.
            /// </summary>
            public void Deletar(Guid id)
            {
                try
                {
                    TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(id)!;

                    if (tipoBuscado != null)
                    {
                        _context.TiposUsuarios.Remove(tipoBuscado);
                    }

                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            /// <summary>
            /// Repositório para gerenciamento dos tipos dos usuario.
            /// </summary>
            public List<TiposUsuarios> Listar()
            {
                try
                {
                    return _context.TiposUsuarios.ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
