using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC.Data
{
    public class Cliente
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "La cédula debe tener 10 dígitos.")]
        public string Cedula { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Formato de correo no válido.")]
        public string Mail { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos.")]
        public string Telefono { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
