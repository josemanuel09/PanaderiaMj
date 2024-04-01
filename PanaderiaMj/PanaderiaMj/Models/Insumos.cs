using System.ComponentModel.DataAnnotations;

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
    }
}
