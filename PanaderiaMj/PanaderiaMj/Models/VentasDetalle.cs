using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class VentasDetalle
    {
        [Key]
        public int DetalleVentaId { get; set; }
        [Required(ErrorMessage = "El Campo Producto es obligatorio")]
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "El Campo Cantidad es obligatorio")]
        [Range(1, 1000, ErrorMessage = "La cantidad debe ser mayor a 0")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El Campo Precio es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El Precio no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public double Precio { get; set; }
    }
}
