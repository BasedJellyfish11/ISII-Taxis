using System;
using System.ComponentModel;

namespace ISII_Taxis.Form_models
{
    using System.ComponentModel.DataAnnotations;
    public class AltaTaxiForm
    {
        [Required(ErrorMessage = "La matrícula es un campo requerido")]
        [MaxLength(10, ErrorMessage = "La matrícula es demasiado larga (tamaño máximo {1})")]
        [RegularExpression(@"[\w]*", ErrorMessage = "La matrícula debe estar compuesta únicamente por letras y números")]
        public string? Matricula { get; set; }
        
        [Required(ErrorMessage = "El identificador de parada inicial es un campo requerido")]
        [Range(0, byte.MaxValue, ErrorMessage = "El identificador de parada no es válido (valores entre 0 y 255)")]
        [RegularExpression(@"[\d]*", ErrorMessage = "El identificador de parada debe ser dígitos")]
        public byte? NumeroParada { get; set; }

        [Required(ErrorMessage = "El identificador de estado inicial es un campo requerido")]
        [Range(0, byte.MaxValue, ErrorMessage = "El identificador de estado no es válido (valores entre 0 y 255)")]
        [RegularExpression(@"[\d]*", ErrorMessage = "El identificador de estado debe ser dígitos")]
        public byte? NumeroEstado { get; set; }
        
        [Required(ErrorMessage = "El numero de plazas es un campo requerido")]
        [Range(0, byte.MaxValue, ErrorMessage = "El numero de plazas no es válido (valores entre 0 y 255)")]
        [RegularExpression(@"[\d]*", ErrorMessage = "El numero de plazas debe ser dígitos")]
        public int? NumeroPlazas { get; set; }
        
        [Required(ErrorMessage = "El email es un campo requerido")]
        [MaxLength(100, ErrorMessage = "El email es demasiado largo (tamaño máximo {1})")]
        [EmailAddress(ErrorMessage = "Por favor, introduzca un email valido")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "La hora a la que el taxi estará disponible es un campo requerido")]
        public DateTime HoraDisponible { get; set; } = DateTime.Now;
    }
}