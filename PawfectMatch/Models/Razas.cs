using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectMatch.Models
{
    public class Razas
    {
        [Key]
        public int RazaId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;

        [ForeignKey("CategoriaId")]
        [InverseProperty("Razas")]
        public Categorias Categoria { get; set; } = null!;
    }
}
