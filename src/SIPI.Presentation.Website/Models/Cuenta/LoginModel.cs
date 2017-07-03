using System.ComponentModel.DataAnnotations;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class LoginModel
    {
        [Required]
        [MaxLength(150)]
        public string User { get; set; }

        [Required]
        [MaxLength(150)]
        public string Password { get; set; }
    }
}