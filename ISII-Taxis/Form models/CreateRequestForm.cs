using System;
using System.ComponentModel;

namespace ISII_Taxis.Form_models
{
    using System.ComponentModel.DataAnnotations;
    public class CreateRequestForm
    {
        [Required(ErrorMessage = "El nombre de usuario es un campo requerido")]
        [MaxLength(50, ErrorMessage = "El nombre de usuario es demasiado largo (tamaño máximo {1})")]
        [RegularExpression(@"[\w]*", ErrorMessage = "El nombre de usuario debe estar compuesto únicamente por letras y números")]
        public string? Username { get; set; }
        
        [Required(ErrorMessage = "La contraseña es un campo requerido")]
        [PasswordPropertyText(true)]
        [MinLength(8, ErrorMessage = "La contraseña no es suficientemente larga (tamaño mínimo {1})")]
        [RegularExpression(@"[\S]*", ErrorMessage = "La contraseña no puede tener espacios")]
        public string? Password { get; set; }    

        [Required(ErrorMessage = "La matrícula es un campo requerido")]
        [MaxLength(10, ErrorMessage = "La matrícula es demasiado larga (tamaño máximo {1})")]
        [RegularExpression(@"[\w]*", ErrorMessage = "La matrícula debe estar compuesta únicamente por letras y números")]
        public string? Matricula { get; set; }
        
        [Required(ErrorMessage = "El identificador de parada inicial es un campo requerido")]
        [Range(0, byte.MaxValue, ErrorMessage = "El identificador de parada no es válido (valores entre 0 y 255)")]
        [RegularExpression(@"[\d]*", ErrorMessage = "El identificador de parada debe ser dígitos")]
        public byte? NumeroParadaInicial { get; set; }
        
        [Required(ErrorMessage = "El identificador de parada inicial es un campo requerido")]
        [Range(0, byte.MaxValue, ErrorMessage = "El identificador de parada no es válido (valores entre 0 y 255)")]
        [RegularExpression(@"[\d]*", ErrorMessage = "El identificador de parada debe ser dígitos")]
        public byte? NumeroParadaFinal { get; set; }
        
        [Required(ErrorMessage = "La hora a la que el taxi estará disponible es un campo requerido")]
        public DateTime FechaDisponible { get; set; } = DateTime.Now.Date;

        [Required(ErrorMessage = "La hora a la que el taxi estará disponible es un campo requerido")]
        public TimeSpan HoraDisponible;

    }
}