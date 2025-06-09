using Microsoft.EntityFrameworkCore;
using MonitoramentoEventos.Models;

namespace MonitoramentoEventos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<LocalMonitorado> LocaisMonitorados { get; set; }
    }
}