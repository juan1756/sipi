using System.ComponentModel.DataAnnotations;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class LoginModel
    {
        [Required]
        [MaxLength(100)]
        public string User { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
    }
}