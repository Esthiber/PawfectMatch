﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawfectMatch.Models._Mascotas
{
    public class Mascotas
    {
        [Key]
        public int MascotaId { get; set; }

        [Required(ErrorMessage = "La categoria es requerida")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Raza es requerido")]
        public int RazaId { get; set; }

        [Required(ErrorMessage = "La relacion de tamaño es requerida")]
        public int RelacionSizeId { get; set; }

        [Required(ErrorMessage = "El Estado es Requerido")]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El Tamaño es requerido")]
        public double Tamano { get; set; } = 0; // Pulgadas

        [Required(ErrorMessage = "La Fecha de nacimiento es requerida")]
        public DateOnly FechaNacimieneto { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "La Foto es requerida")]
        public string FotoUrl { get; set; } = null!;

        [ForeignKey("CategoriaId")]
        public Categorias Categoria { get; set; } = null!;

        [ForeignKey("RelacionSizeId")]
        public RelacionSizes RelacionSize { get; set; } = null!;

        [ForeignKey("EstadoId")]
        public Estados Estado { get; set; } = null!;

    }
}
