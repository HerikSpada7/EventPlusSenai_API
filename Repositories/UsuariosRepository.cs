using EventPlus_API.Contexts;
using EventPlus_API.Domains;
using EventPlus_API.Interfaces;
using EventPlus_API.Utils;

namespace EventPlus_API.Repositories
{
    /// <summary>
    /// Repositório para gerenciamento dos usuarios
    /// </summary>
    public class UsuariosRepository : IUsuarioRepository
    {
        private readonly EventosContext _context;

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public UsuariosRepository(EventosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuarios
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado!;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuarios
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            IdTipoUsuario = u.TipoUsuario!.IdTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;

                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public void Cadastrar(Usuarios usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.NewGuid();

                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);


                _context.Usuarios.Add(usuario);


                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos usuarios
        /// </summary>
        public List<Usuarios> Listar()
        {
            try
            {
                return _context.Usuarios
                    .OrderBy(tp => tp.Nome)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}