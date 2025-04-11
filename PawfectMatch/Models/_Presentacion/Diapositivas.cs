using System.ComponentModel.DataAnnotations;

namespace PawfectMatch.Models._Presentacion
{
    public class Diapositivas
    {
        [Key]
        public int DiapositivaId { get; set; }

        public bool IsTituloLeftActive { get; set; }
        public string? Titulo_Left { get; set; }
        public string? SubTitulo_Left { get; set; }

        public bool IsTituloRightActive { get; set; }
        public string? Titulo_Right { get; set; }
        public string? SubTitulo_Right { get; set; }

        public bool IsButtonLefttActive { get; set; }
        public string? TextButton_Left { get; set; }
        public string? LinkButton_Left { get; set; }

        public bool IsButtonRighttActive { get; set; }
        public string? TextButton_Right { get; set; }
        public string? LinkButton_Right { get; set; }

        [Required(ErrorMessage ="Imagen de fondo Requerida")]
        public string ImageUrl { get; set; } = null!;

        public int Orden { get; set; }

        public string? Animacion { get; set; }

    }
}
