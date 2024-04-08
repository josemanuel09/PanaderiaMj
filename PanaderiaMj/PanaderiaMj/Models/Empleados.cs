using System.ComponentModel.DataAnnotations;

namespace PanaderiaMj.Models
{
    public class Empleados
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo no acepta digitos")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Telefono es obligatorio")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Escriba el teléfono correctamente xxx-xxx-xxxx")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El Campo Fecha De Ingreso es obligatorio")]
        public DateTime FechaIngreso { get; set; }
        [Required(ErrorMessage = "El Campo Direccion es obligatorio")]

        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El Campo Cedula es obligatorio")]
        [StringLength(13, ErrorMessage = "La cedula debe tener 11 caracteres")]
        
        public string? Cedula { get; set; }
    }
}
