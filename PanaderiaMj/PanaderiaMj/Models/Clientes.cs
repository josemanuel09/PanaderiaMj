using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "EL Campo Fecha es obligatoria")]

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El Campo Nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]

        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El Campo Cedula es obligatoria")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Este campo solo acepta números")]
        [MinLength(11, ErrorMessage = "La cedula debe tener 11 digitos")]
        public string? Cedula { get; set; }
        [Required(ErrorMessage = "El Email es obligatorio")]
        [EmailAddress(ErrorMessage = "Este campo debe ser un Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El Campo Direccion es obligatorio")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El Campo Telefono es obligatorio")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Escriba el teléfono correctamente xxx-xxx-xxxx")]

        public string? Telefono { get; set; }
    }
}
