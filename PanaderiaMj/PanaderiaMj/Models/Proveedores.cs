using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Fecha es obligatorio")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El Campo Direccion es obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El Campo Telefono es obligatorio")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]

        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "Este campo debe ser un correo electrónico")]
        public string? Email { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        [Required(ErrorMessage = "El Campo RNC campo es obligatorio")]
        public string? RNC { get; set; }
        [Required(ErrorMessage = "El Campo Tipo de Contribuyente es obligatorio")]
        public string? TipoContribuyente { get; set; }
        public string? Nota { get; set; }
    }
}
