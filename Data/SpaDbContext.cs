using Microsoft.EntityFrameworkCore;
using Spa.Models;

namespace Spa.Data
{
    public class SpaDbContext : DbContext
    {
        public SpaDbContext(DbContextOptions<SpaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── Cliente ──────────────────────────────────────────────────────
            modelBuilder.Entity<Cliente>(e =>
            {
                e.Property(c => c.Dni)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(c => c.Nombre)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(c => c.Apellido)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(c => c.TipoCliente)
                    .IsRequired()
                    .HasDefaultValue("Regular");

                // Correo y Password son opcionales (clientes invitados no los tienen)
                e.Property(c => c.Correo)
                    .IsRequired(false);

                e.Property(c => c.Password)
                    .IsRequired(false);
            });

            // ── Servicio ─────────────────────────────────────────────────────
            modelBuilder.Entity<Servicio>(e =>
            {
                e.Property(s => s.Nombre)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(s => s.Duracion)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);
            });

            // ── Promocion ────────────────────────────────────────────────────
            modelBuilder.Entity<Promocion>(e =>
            {
                e.Property(p => p.Nombre)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(p => p.Descripcion)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(p => p.Imagen)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);
            });

            // ── Administrador ────────────────────────────────────────────────
            modelBuilder.Entity<Administrador>(e =>
            {
                e.Property(a => a.Usuario)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);

                e.Property(a => a.Password)
                    .IsRequired()
                    .HasDefaultValue(string.Empty);
            });
        }
    }
}
