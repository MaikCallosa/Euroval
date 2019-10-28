using Microsoft.EntityFrameworkCore;

namespace Euroval.Entity.Entity
{
    public partial class EurovalContext : DbContext
    {
        public EurovalContext()
        {
        }

        public EurovalContext(DbContextOptions<EurovalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deporte> Deporte { get; set; }
        public virtual DbSet<Pista> Pista { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Socio> Socio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Pista>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Deporte)
                    .WithMany(p => p.Pista)
                    .HasForeignKey(d => d.DeporteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pista_Deporte");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasIndex(e => new { e.SocioId, e.PistaId, e.FechaInicio, e.FechaFin })
                    .HasName("UC_Reserva")
                    .IsUnique();

                entity.HasOne(d => d.Pista)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.PistaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Pista");

                entity.HasOne(d => d.Socio)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.SocioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Socio");
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(9);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Contrasenya).HasMaxLength(100);

                entity.Property(e => e.NombreUsuario)
                    .HasColumnName("Usuario")
                    .HasMaxLength(100);

                entity.Property(e => e.Token).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
