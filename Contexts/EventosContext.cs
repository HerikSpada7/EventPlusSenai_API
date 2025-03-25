using Microsoft.EntityFrameworkCore;
using EventPlus_API.Domains;

namespace EventPlus_API.Contexts
{
    public class EventosContext : DbContext
    {
        public EventosContext()
        {
        }
        public EventosContext(DbContextOptions<EventosContext> options)
            : base(options)
        {
        }

        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<TiposEventos> TiposEventos { get; set; }

        public DbSet<Eventos> Eventos { get; set; }

        public DbSet<ComentariosEventos> ComentariosEventos { get; set; }

        public DbSet<Instituicoes> Instituicoes { get; set; }

        public DbSet<Presencas> Presencas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= DESKTOP-0HO9ARA\\SQLEXPRESS; Database=EventPlus_API; User id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }
        }
    }
}