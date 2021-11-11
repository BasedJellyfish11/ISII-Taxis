using System.ComponentModel;

namespace ISII_Taxis.Form_models
{
    using System.ComponentModel.DataAnnotations;
    public class AltaUsuarioForm
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
        
        [PasswordPropertyText(true)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string? PasswordRepeat { get; set; }
        
        [Required(ErrorMessage = "La direccion es un campo requerido")]
        [MaxLength(500, ErrorMessage = "La dirección es demasiado larga (tamaño máximo {1})")]
        [RegularExpression(@"[\wª\., ]*", ErrorMessage = "Hay caracteres inválidos en la dirección")]
        public string? Direccion { get; set; }
        
        [Required(ErrorMessage = "El email es un campo requerido")]
        [MaxLength(100, ErrorMessage = "El email es demasiado largo (tamaño máximo {1})")]
        [EmailAddress(ErrorMessage = "Por favor, introduzca un email valido")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "El teléfono es un campo requerido")]
        [MaxLength(15,ErrorMessage = "Los teléfonos pueden tener como máximo {1} caracteres")]
        [Phone(ErrorMessage = "Introduzca un teléfono válido")]
        public string? Teléfono { get; set; }
        
    }
}