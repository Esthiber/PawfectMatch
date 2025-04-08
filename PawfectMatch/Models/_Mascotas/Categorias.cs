using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectMatch.Models._Mascotas
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage ="Requerido")]
        public string Nombre { get; set; } = null!;

        [InverseProperty("Categoria")]
        public ICollection<Razas> Razas { get; set; } = new List<Razas>();
    }
}
