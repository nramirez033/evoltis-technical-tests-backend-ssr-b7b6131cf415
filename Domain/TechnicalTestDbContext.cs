using Microsoft.EntityFrameworkCore;
using technical_tests_backend_ssr.Models;

namespace technical_tests_backend_ssr.Domain
{
    public class TechnicalTestDbContext : DbContext
    {
        public TechnicalTestDbContext(DbContextOptions<TechnicalTestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleados");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Puesto)
                      .HasMaxLength(100);

                entity.Property(e => e.FechaIngreso)
                      .HasColumnType("datetime");
            });
        }
    }
}
