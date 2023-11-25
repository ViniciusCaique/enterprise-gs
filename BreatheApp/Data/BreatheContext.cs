using BreatheApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BreatheApp.Data
{
    public class BreatheContext : DbContext
    {
        public BreatheContext(DbContextOptions<BreatheContext> options) : base(options) { }

        public DbSet<Doenca> Doencas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doenca>().ToTable("Doenca");
            modelBuilder.Entity<Diagnostico>().ToTable("Diagnostico");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }

        public DbSet<BreatheApp.Models.Endereco> Endereco { get; set; } = default!;
    }
}
