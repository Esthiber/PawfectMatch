using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectMatch.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;

        [InverseProperty("Categoria")]
        public ICollection<Razas> Razas { get; set; } = new List<Razas>();
    }
}
