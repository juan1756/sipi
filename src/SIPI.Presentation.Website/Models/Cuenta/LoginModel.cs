using System.ComponentModel.DataAnnotations;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo Email es requerido")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de email válida")]
        [MaxLength(150, ErrorMessage = "El campo Email puede contener como máximo 150 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Contraseña puede contener como máximo 150 caracteres")]
        public string Contrasena { get; set; }
    }
}