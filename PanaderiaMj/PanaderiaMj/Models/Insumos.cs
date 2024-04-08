using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanaderiaMj.Models
{
    public class Insumos
    {
        [Key]
        public int InsumoId { get; set; }

        [Required(ErrorMessage = "El Campo Nombre obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Cantidad obligatorio")]
        public int CantidadDisponible { get; set; }
        [Required(ErrorMessage = "El Campo Fecha Registro es obligatorio")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El Campo Proveedor es obligatorio")]
        [ForeignKey("ProveedorId")]
        public int ProveedorId { get; set; }
    }
}
