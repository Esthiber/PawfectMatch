using Microsoft.EntityFrameworkCore;
using PawfectMatch.Models;
using PawfectMatch.Models._Mascotas;
using PawfectMatch.Models._Solicitudes;

namespace PawfectMatch.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }


        DbSet<Citas> Citas { get; set; }
        DbSet<HistorialAdopciones> HistorialAdopciones { get; set; }

        DbSet<SolicitudesAdopciones> SolicitudesAdopciones { get; set; }

        DbSet<EstadoSolicitudes> EstadoSolicitudes { get; set; }
        DbSet<Adoptantes> Adoptantes { get; set; }
        DbSet<Mascotas> Mascotas { get; set; }
        DbSet<Sexos> Sexos { get; set; }
        DbSet<Razas> Razas { get; set; }
        DbSet<Categorias> Categorias { get; set; }
        DbSet<RelacionSizes> RelacionSizes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre Categorias y Razas
            modelBuilder.Entity<Categorias>()
                .HasMany(c => c.Razas)
                .WithOne(r => r.Categoria)
                .HasForeignKey(r => r.CategoriaId);

            // Configuración de la relación entre Mascotas y Razas
            modelBuilder.Entity<Mascotas>()
                .HasOne(m => m.Raza)
                .WithMany()
                .HasForeignKey(m => m.RazaId);

            // Configuración de la relación entre Mascotas y Categorias
            modelBuilder.Entity<Mascotas>()
                .HasOne(m => m.Categoria)
                .WithMany()
                .HasForeignKey(m => m.CategoriaId);

            // Configuración de la relación entre Mascotas y RelacionSizes
            modelBuilder.Entity<Mascotas>()
                .HasOne(m => m.RelacionSize)
                .WithMany()
                .HasForeignKey(m => m.RelacionSizeId);

            // Configuración de la relación entre Mascotas y Estados
            modelBuilder.Entity<Mascotas>()
                .HasOne(m => m.Estado)
                .WithMany()
                .HasForeignKey(m => m.EstadoId);

            // Configuración de la relación entre SolicitudesAdopciones y Mascotas
            modelBuilder.Entity<SolicitudesAdopciones>()
                .HasOne(s => s.Mascota)
                .WithMany()
                .HasForeignKey(s => s.MascotaId);

            // Configuración de la relación entre HistorialAdopciones y Mascotas
            modelBuilder.Entity<HistorialAdopciones>()
                .HasOne(h => h.Mascota)
                .WithMany()
                .HasForeignKey(h => h.MascotaId);

            // Configuración de la relación entre Citas y Mascotas
            modelBuilder.Entity<Citas>()
                .HasOne(c => c.Mascota)
                .WithMany()
                .HasForeignKey(c => c.MascotaId);

            // Configuración de la relación entre Citas y Adoptantes
            modelBuilder.Entity<Citas>()
                .HasOne(c => c.Adoptante)
                .WithMany()
                .HasForeignKey(c => c.AdoptanteId);

            // Configuración de la relación entre SolicitudesAdopciones y Adoptantes
            modelBuilder.Entity<SolicitudesAdopciones>()
                .HasOne(s => s.Adoptante)
                .WithMany()
                .HasForeignKey(s => s.AdoptanteId);

            // Configuración de la relación entre SolicitudesAdopciones y EstadoSolicitudes
            modelBuilder.Entity<SolicitudesAdopciones>()
                .HasOne(s => s.EstadoSolicitud)
                .WithMany()
                .HasForeignKey(s => s.EstadoSolicitudId);

            // Configuración de la relación entre HistorialAdopciones y Adoptantes
            modelBuilder.Entity<HistorialAdopciones>()
                .HasOne(h => h.Adoptante)
                .WithMany()
                .HasForeignKey(h => h.AdoptanteId);


            // Inserción de datos iniciales
            modelBuilder.Entity<Categorias>().HasData(
                new Categorias { CategoriaId = 1, Nombre = "Perros" },
                new Categorias { CategoriaId = 2, Nombre = "Gatos" }
            );

            modelBuilder.Entity<Razas>().HasData(
                new Razas { RazaId = 1, CategoriaId = 1, Nombre = "Labrador" },
                new Razas { RazaId = 2, CategoriaId = 1, Nombre = "Bulldog" },
                new Razas { RazaId = 3, CategoriaId = 2, Nombre = "Persa" },
                new Razas { RazaId = 4, CategoriaId = 2, Nombre = "Siamés" }
            );

            modelBuilder.Entity<RelacionSizes>().HasData(
                new RelacionSizes { RelacionSizeId = 1, Size = "Pequeño" },
                new RelacionSizes { RelacionSizeId = 2, Size = "Mediano" },
                new RelacionSizes { RelacionSizeId = 3, Size = "Grande" }
            );

            modelBuilder.Entity<Estados>().HasData(
                new Estados { EstadoId = 1,Nombre = "Disponible" },
                new Estados { EstadoId = 2, Nombre = "Adoptado" },
                new Estados { EstadoId = 2, Nombre = "No Disponible" }
            );

            modelBuilder.Entity<Sexos>().HasData(
                new Sexos { SexoId = 1, Nombre = "Macho" },
                new Sexos { SexoId = 2, Nombre = "Hembra" }
            );

            modelBuilder.Entity<EstadoSolicitudes>().HasData(
                new EstadoSolicitudes { EstadoSolicitudId = 1, Nombre = "Pendiente" },
                new EstadoSolicitudes { EstadoSolicitudId = 2, Nombre = "Aprobada" },
                new EstadoSolicitudes { EstadoSolicitudId = 3, Nombre = "Rechazada" }
            );

        }
    }
}
