using System;
using System.ComponentModel;

namespace ISII_Taxis.Form_models
{
    using System.ComponentModel.DataAnnotations;
    public class DeleteTaxiForm
    {
        [Required(ErrorMessage = "La matrícula es un campo requerido")]
        [MaxLength(10, ErrorMessage = "La matrícula es demasiado larga (tamaño máximo {1})")]
        [RegularExpression(@"[\w]*", ErrorMessage = "La matrícula debe estar compuesta únicamente por letras y números")]
        public string? Matricula { get; set; }
        
    }
}