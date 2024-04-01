using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        [Required(ErrorMessage = "El Campo Proveedor es obligatorio")]
        [ForeignKey("ProveedorId")]
        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "El Campo Metodo de Pago es obligatorio")]

        public string? MetodoDePago { get; set; }
        [Required(ErrorMessage = "El campo Monto Total es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El Monto Total no puede ser negativo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]

        public double MontoTotal { get; set; }
        [Required(ErrorMessage = "El Campo Fecha es obligatorio")]
        public DateTime FechaPedida { get; set; } = DateTime.Now;
        public string? Observaciones { get; set; }

        [ForeignKey("CompraId")]
        public ICollection<ComprasDetalle> ComprasDetalle { get; set; } = new List<ComprasDetalle>();
    }
}
