using Microsoft.EntityFrameworkCore;
using EventPlus_API.Contexts;
using EventPlus_API.Domains;
using EventPlus_API.Interfaces;

namespace EventPlus_API.Repositories
{
    public class EventosRepository : IEventosRepository
    {
        private readonly EventosContext _context;

        public EventosRepository(EventosContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Eventos evento)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                }

                _context.Eventos.Update(eventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Domains.Eventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.Eventos
                    .Select(e => new Eventos
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TiposEvento = new TiposEventos
                        {
                            TituloTipoEvento = e.TiposEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicoes
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.IdEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Domains.Eventos evento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (evento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                evento.IdEvento = Guid.NewGuid();

                _context.Eventos.Add(evento);

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
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Domains.Eventos> Listar()
        {
            try
            {
                return _context.Eventos
                    .Select(e => new Eventos
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TiposEvento = new TiposEventos
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TiposEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicoes
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Domains.Eventos> ListarPorId(Guid id)
        {
            try
            {
                return _context.Eventos
                    .Include(e => e.Presencas)
                    .Select(e => new Eventos
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TiposEvento = new TiposEventos
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TiposEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicoes
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        },
                        Presencas = new Presencas
                        {
                            IdUsuario = e.Presencas!.IdUsuario,
                            Situacao = e.Presencas!.Situacao
                        }
                    })
                    .Where(e => e.Presencas!.Situacao == true && e.Presencas.IdUsuario == id)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Domains.Eventos> ProximosEventos()
        {
            try
            {
                return _context.Eventos
                    .Select(e => new Eventos
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TiposEvento = new TiposEventos
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TiposEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicoes
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}