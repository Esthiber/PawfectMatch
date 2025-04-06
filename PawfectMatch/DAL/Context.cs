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

    }
}
