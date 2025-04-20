using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawfectMatch.Models._Mascotas;
using PawfectMatch.Models._Solicitudes;
using PawfectMatch.Models;
using System.Reflection.Emit;
using PawfectMatch.Models._Presentacion;
using PawfectMatch.Models._Servicios;

namespace PawfectMatch.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    #region DbSets
    public DbSet<Citas> Citas { get; set; }

    public DbSet<HistorialAdopciones> HistorialAdopciones { get; set; }

    public DbSet<SolicitudesAdopciones> SolicitudesAdopciones { get; set; }

    public DbSet<EstadoSolicitudes> EstadoSolicitudes { get; set; }

    public DbSet<Adoptantes> Adoptantes { get; set; }

    public DbSet<Mascotas> Mascotas { get; set; }

    public DbSet<Sexos> Sexos { get; set; }

    public DbSet<Razas> Razas { get; set; }

    public DbSet<Categorias> Categorias { get; set; }

    public DbSet<RelacionSizes> RelacionSizes { get; set; }

    public DbSet<Estados> Estados { get; set; }

    public DbSet<Sugerencias> Sugerencias { get; set; }

    public DbSet<Presentaciones> Presentaciones { get; set; }
    public DbSet<PresentacionesDiapositivas> PresentacionesDiapositivas { get; set; }
    public DbSet<Diapositivas> Diapositivas { get; set; }

    public DbSet<Servicios> Servicios { get; set; }
    public DbSet<SolicitudesServicios> SolicitudesServicios { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Configuraciones

        modelBuilder.Entity<Mascotas>()
            .HasOne(m => m.Categoria)
            .WithMany()
            .HasForeignKey(m => m.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Mascotas>()
            .HasOne(m => m.RelacionSize)
            .WithMany()
            .HasForeignKey(m => m.RelacionSizeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Mascotas>()
            .HasOne(m => m.Estado)
            .WithMany()
            .HasForeignKey(m => m.EstadoId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SolicitudesAdopciones>()
            .HasOne(s => s.Mascota)
            .WithMany()
            .HasForeignKey(s => s.MascotaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<HistorialAdopciones>()
            .HasOne(h => h.Mascota)
            .WithMany()
            .HasForeignKey(h => h.MascotaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Citas>()
            .HasOne(c => c.Mascota)
            .WithMany()
            .HasForeignKey(c => c.MascotaId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Citas>()
            .HasOne(c => c.Adoptante)
            .WithMany()
            .HasForeignKey(c => c.AdoptanteId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SolicitudesAdopciones>()
            .HasOne(s => s.Adoptante)
            .WithMany()
            .HasForeignKey(s => s.AdoptanteId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SolicitudesAdopciones>()
            .HasOne(s => s.EstadoSolicitud)
            .WithMany()
            .HasForeignKey(s => s.EstadoSolicitudId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<HistorialAdopciones>()
            .HasOne(h => h.Adoptante)
            .WithMany()
            .HasForeignKey(h => h.AdoptanteId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<SolicitudesServicios>()
            .HasKey(ss => ss.SolicitudServicioId);

        modelBuilder.Entity<SolicitudesServicios>()
            .HasOne(ss => ss.SolicitudAdopcion)
            .WithMany(s => s.SolicitudesServicios)
            .HasForeignKey(ss => ss.SolicitudAdopcionId)
            .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region Initial Seed
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
            new Estados { EstadoId = 1, Nombre = "Disponible" },
            new Estados { EstadoId = 2, Nombre = "Adoptado" },
            new Estados { EstadoId = 3, Nombre = "No Disponible" }
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

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
        );

        modelBuilder.Entity<Presentaciones>().HasData(
            new Presentaciones
            {
                PresentacionId = 1,
                Titulo = "Default",
                EsActiva = true,
                Descripcion = "Esta es la presentacion default. No la borre por favor."
            }
        );

        modelBuilder.Entity<Diapositivas>().HasData(
            new Diapositivas
            {
                DiapositivaId = 1,
                IsTituloLeftActive = true,
                Titulo_Left = "Encuentra a tu compañero perfecto",
                SubTitulo_Left = "Conectamos mascotas que necesitan un hogar con familias amorosas",

                IsButtonLeftActive = true,
                TextButton_Left = "Explorar Mascotas",
                LinkButton_Left = Urls.Mascotas.Index,

                ImageUrl = "https://images-ext-1.discordapp.net/external/pCPvCTsMyhwvSzSxaPZZ5PG8VfVshz1DMFeTU4VQBFo/https/images8.alphacoders.com/449/thumb-1920-449501.jpg?format=webp&width=1374&height=859",
                Orden = 1
            },
            new Diapositivas
            {
                DiapositivaId = 2,
                IsTituloLeftActive = true,
                Titulo_Left = "Adopta, no compres",
                SubTitulo_Left = "Dale una segunda oportunidad a quienes más lo necesitan",

                IsButtonLeftActive = true,
                TextButton_Left = "Ver Historias",
                LinkButton_Left = "#",

                ImageUrl = "https://cdn.pixabay.com/photo/2016/11/29/04/17/dog-1861839_1280.jpg",
                Orden = 2
            },
            new Diapositivas
            {
                DiapositivaId = 3,
                IsTituloLeftActive = false,
                IsTituloRightActive = true,
                Titulo_Right = "Historias con final feliz",
                SubTitulo_Right = "Conoce cómo nuestras mascotas encontraron un hogar lleno de amor",

                IsButtonRightActive = true,
                TextButton_Right = "Leer historias",
                LinkButton_Right = "#testimonials-section",

                ImageUrl = "https://cdn.pixabay.com/photo/2020/02/06/15/06/dog-4824485_1280.jpg",
                Orden = 3
            }

        );

        modelBuilder.Entity<PresentacionesDiapositivas>().HasData(
            new PresentacionesDiapositivas()
            {
                PresentacionDiapositivaId = 1,
                PresentacionId = 1,
                DiapositivaId = 1,
                Orden = 1
            },
             new PresentacionesDiapositivas()
             {
                 PresentacionDiapositivaId = 2,
                 PresentacionId = 1,
                 DiapositivaId = 2,
                 Orden = 2
             },
              new PresentacionesDiapositivas()
              {
                  PresentacionDiapositivaId = 3,
                  PresentacionId = 1,
                  DiapositivaId = 3,
                  Orden = 3
              }
        );

        modelBuilder.Entity<Servicios>().HasData(
            new Servicios
            {
                ServicioId = 1,
                Nombre = "Documentos de Adopción",
                Descripcion = "Documentos que certifican la propiedad de la mascota.",
                Costo = 0.00
            },
           new Servicios
           {
               ServicioId = 2,
               Nombre = "Vacunación",
               Descripcion = "Servicio de vacunación para mascotas.",
               Costo = 500.00
           },
           new Servicios
           {
               ServicioId = 3,
               Nombre = "Desparasitación",
               Descripcion = "Tratamiento para eliminar parásitos internos y externos.",
               Costo = 300.00
           },
           new Servicios
           {
               ServicioId = 4,
               Nombre = "Corte de Uñas",
               Descripcion = "Servicio de corte de uñas para mascotas pequeñas y grandes.",
               Costo = 150.00
           },
           new Servicios
           {
               ServicioId = 5,
               Nombre = "Consulta Veterinaria",
               Descripcion = "Consulta general con un veterinario calificado.",
               Costo = 800.00
           }
        );

        modelBuilder.Entity<Mascotas>().HasData(
        new Mascotas()
        {
            MascotaId = 1,
            CategoriaId = 1,
            RazaId = 5,
            RelacionSizeId = 1,
            EstadoId = 1,
            Nombre = "Felipe",
            Tamano = 25,
            FechaNacimiento = DateOnly.Parse("2025-04-02"),
            Descripcion = "Es grande es bonito es un perro loco.",
            FotoUrl = "https://media.istockphoto.com/id/1465311007/es/foto/un-perro-peque%C3%B1o-sonr%C3%ADe-al-due%C3%B1o-peque%C3%B1as-mordeduras-de-mascotas-peligroso-terrier-de-juguete.jpg?s=612x612&w=0&k=20&c=nZzhW0piLl7oIrielT9JA7vAcXqaepnDhCggxD7JZ0I=",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 2,
            CategoriaId = 1,
            RazaId = 1,
            RelacionSizeId = 3,
            EstadoId = 2,
            Nombre = "Milo",
            Tamano = 18,
            FechaNacimiento = DateOnly.Parse("2022-08-08"),
            Descripcion = "Es un perrito muy cariñoso y con mucha energia",
            FotoUrl = "https://th.bing.com/th/id/OIP.TfniUPx7NqEggeKV9APOZgHaE8?rs=1&pid=ImgDetMain",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 3,
            CategoriaId = 1,
            RazaId = 2,
            RelacionSizeId = 1,
            EstadoId = 2,
            Nombre = "Roky",
            Tamano = 16,
            FechaNacimiento = DateOnly.Parse("2021-06-08"),
            Descripcion = "Es un perrito que adora pasear y comer",
            FotoUrl = "https://http2.mlstatic.com/D_NQ_NP_660656-MLM46803871812_072021-F.jpg",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 4,
            CategoriaId = 1,
            RazaId = 5,
            RelacionSizeId = 3,
            EstadoId = 1,
            Nombre = "Willi",
            Tamano = 24,
            FechaNacimiento = DateOnly.Parse("2024-03-08"),
            Descripcion = "Es un perro jugueton y le gusta dormir",
            FotoUrl = "https://th.bing.com/th/id/R.69b9a203e86486a2114bc7380d204970?rik=kimEIahYLupgjQ&pid=ImgRaw&r=0&sres=1&sresct=1",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 5,
            CategoriaId = 1,
            RazaId = 6,
            RelacionSizeId = 1,
            EstadoId = 1,
            Nombre = "lali",
            Tamano = 9,
            FechaNacimiento = DateOnly.Parse("2024-01-07"),
            Descripcion = "Es un perrito muy tierno y adora jugar",
            FotoUrl = "https://www.publicdomainpictures.net/pictures/180000/velka/chihuaua-puppy.jpg",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 6,
            CategoriaId = 1,
            RazaId = 1,
            RelacionSizeId = 3,
            EstadoId = 1,
            Nombre = "Mango",
            Tamano = 16,
            FechaNacimiento = DateOnly.Parse("2024-10-22 "),
            Descripcion = "Es un perrito muy aventurero",
            FotoUrl = "https://th.bing.com/th/id/OIP.NA3_b8GubIn0nfMn0w4XDAHaE8?rs=1&pid=ImgDetMain",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 7,
            CategoriaId = 1,
            RazaId = 7,
            RelacionSizeId = 1,
            EstadoId = 1,
            Nombre = "rodolf",
            Tamano = 9,
            FechaNacimiento = DateOnly.Parse("2023-11-08"),
            Descripcion = "Le encanta correr y comer",
            FotoUrl = "https://th.bing.com/th/id/OIP.EzwbKs8GJQPv0CCPP2GMlQHaD9?rs=1&pid=ImgDetMain",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 8,
            CategoriaId = 1,
            RazaId = 8,
            RelacionSizeId = 2,
            EstadoId = 1,
            Nombre = "Oli",
            Tamano = 10,
            FechaNacimiento = DateOnly.Parse("2021-04-06"),
            Descripcion = "Es un perro que adora el cariño y los paseos largos",
            FotoUrl = "https://th.bing.com/th/id/OIP.v3rbPJHS2RVJFSlRq_DXTAHaE8?rs=1&pid=ImgDetMain",
            SexoId = 1
        },
        new Mascotas()
        {
            MascotaId = 9,
            CategoriaId = 1,
            RazaId = 6,
            RelacionSizeId = 1,
            EstadoId = 1,
            Nombre = "Lalo",
            Tamano = 10,
            FechaNacimiento = DateOnly.Parse("2023-04-12"),
            Descripcion = "Es un perro con mucha energia y adora que le den cariño",
            FotoUrl = "https://th.bing.com/th/id/OIP.JuzlhHcoLZR61J50nJgftwHaFr?rs=1&pid=ImgDetMain",
            SexoId = 1
        });
        #endregion
    }
}