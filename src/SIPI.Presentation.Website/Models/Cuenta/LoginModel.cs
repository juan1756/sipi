using System.ComponentModel.DataAnnotations;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string Contrasena { get; set; }
    }
}