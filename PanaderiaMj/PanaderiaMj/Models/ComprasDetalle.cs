using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class ComprasDetalle
    {
        [Key]
        public int CompraDetalleId { get; set; }
        [ForeignKey("InsumoId")]
        [Required(ErrorMessage = "El Campo Insumo es obligatorio")]
        public int InsumoId { get; set; }
        [ForeignKey("ProveedorId")]
        [Required(ErrorMessage = "El Campo Proveedor es obligatorio")]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "El Campo Cantidad es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El Campo Precio es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El Precio no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El Campo Monto es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El Monto no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public double Monto { get; set; }
    }
}
