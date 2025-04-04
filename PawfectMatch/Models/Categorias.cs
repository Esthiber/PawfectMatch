using System.ComponentModel.DataAnnotations;

namespace PawfectMatch.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
