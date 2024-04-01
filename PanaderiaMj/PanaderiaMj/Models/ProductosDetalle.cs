using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class ProductosDetalle
    {
        [Key]
        public int ProductoDetalleId { get; set; }
        [Required(ErrorMessage = "El Campo Insumo es Obligatorio")]
        [ForeignKey("InsumoId")]
        public int InsumoId { get; set; }

        [Required(ErrorMessage = "El Campo Cantidad es Obligatorio")]
        public int Cantidad { get; set; }
    }
}
