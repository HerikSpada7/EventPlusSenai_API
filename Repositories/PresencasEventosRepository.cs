using EventPlus_API.Contexts;
using EventPlus_API.Domains;
using EventPlus_API.Interfaces;

namespace EventPlus_API.Repositories
{
    public class PresencasRepository : IPresencasRepository
    {
        private readonly Contexts.EventosContext _context;

        public PresencasRepository(Contexts.EventosContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Presencas presencaEvento)
        {
            try
            {
                Presencas presencaEventoBuscado = _context.Presencas.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.Presencas.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Presencas BuscarPorId(Guid id)
        {
            try
            {
                return _context.Presencas
                    .Select(p => new Presencas
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Evento = new Eventos
                        {
                            IdEvento = p.IdEvento!,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresencaEvento == id)!;
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
                Presencas presencaEventoBuscado = _context.Presencas.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.Presencas.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(Presencas inscricao)
        {
            try
            {
                inscricao.IdPresencaEvento = Guid.NewGuid();

                _context.Presencas.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presencas> Listar()
        {

            try
            {
                return _context.Presencas
                    .Select(p => new Presencas
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Evento = new Eventos
                        {
                            IdEvento = p.IdEvento,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presencas> ListarMinhas(Guid id)
        {
            return _context.Presencas
                .Select(p => new Presencas
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,

                    Evento = new Eventos
                    {
                        IdEvento = p.IdEvento,
                        DataEvento = p.Evento!.DataEvento,
                        NomeEvento = p.Evento!.NomeEvento,
                        Descricao = p.Evento!.Descricao,

                        Instituicao = new Instituicoes
                        {
                            IdInstituicao = p.Evento!.IdInstituicao,
                        }
                    }
                })
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}