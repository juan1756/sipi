using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class RecuperoConfirmarModel : LoginModel
    {
        [Required]
        [MaxLength(150)]
        [Compare(nameof(Contrasena))]
        public string ConfirmarContrasena { get; set; }

        [Required]
        public string Token { get; set; }
    }
}