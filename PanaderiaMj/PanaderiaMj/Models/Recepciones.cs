﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanaderiaMj.Models
{
    public class Recepciones
    {
        [Key]
        public int RecepcionId { get; set; }
        [Required(ErrorMessage = "El Producto es requerido")]
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El Concepto es requerido")]
        public string? Concepto { get; set; }
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La Direccion es requerida")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido")]
        public string? Telefono { get; set; }
    }
}
