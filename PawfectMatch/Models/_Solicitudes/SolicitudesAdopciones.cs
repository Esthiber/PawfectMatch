using PawfectMatch.Models._Mascotas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectMatch.Models._Solicitudes
{
    public class SolicitudesAdopciones
    {
        [Key]
        public int SolicitudAdopcionId { get; set; }

        public int AdoptanteId { get; set; }

        public DateTime Fecha { get; set; }

        public int EstadoSolicitudId { get; set; }

        public int MascotaId { get; set; }

        [ForeignKey("AdoptanteId")]
        public Adoptantes Adoptante { get; set; } = null!;

        [ForeignKey("EstadoSolicitudId")]
        public EstadoSolicitudes EstadoSolicitud { get; set; } = null!;

        [ForeignKey("MascotaId")]
        public Mascotas Mascota { get; set; } = null!;

    }
}
