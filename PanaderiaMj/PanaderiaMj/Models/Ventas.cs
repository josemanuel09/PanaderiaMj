using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        [Required(ErrorMessage = "El Campo Fecha es obligatorio")]
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El Campo Cliente es obligatorio")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El Campo Concepto es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Este campo solo acepta letras")]
        public string? Concepto { get; set; }
        [Required(ErrorMessage = "El Campo Tipo de Venta es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Este campo solo acepta letras")]
        public string? TipoVenta { get; set; }
        [Required(ErrorMessage = "El Campo Sub Total es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El SubTotal no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public double SubTotal { get; set; }
        [Required(ErrorMessage = "El Campo Monto Total es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El Monto Total no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        public double MontoTotal { get; set; }

        [ForeignKey("VentaId")]
        public ICollection<VentasDetalle> DetalleVentas { get; set; } = new List<VentasDetalle>();
    }
}
