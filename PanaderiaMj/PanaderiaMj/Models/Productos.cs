using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "El Campo Producto es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Descripcion es obligatorio")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El Campo Fecha es obligatorio")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El Campo Precio es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El Precio no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public double PrecioProducto { get; set; }
        [Required(ErrorMessage = "El Campo Cantidad es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public int CantidadAProducir { get; set; }
        public string? Nota { get; set; }

        [ForeignKey("ProductoId")]
        public ICollection<ProductosDetalle> ProductosDetalle { get; set; } = new List<ProductosDetalle>()
    }
}
