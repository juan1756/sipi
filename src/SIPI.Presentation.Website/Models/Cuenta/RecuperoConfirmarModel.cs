using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class RecuperoConfirmarModel
    {
        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}