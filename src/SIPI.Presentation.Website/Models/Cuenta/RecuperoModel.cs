using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class RecuperoModel : LoginModel
    {
        [Display(Name = "Confirmación de contraseña")]
        [Required(ErrorMessage = "El campo confirmación de contraseña es requerido")]
        [MaxLength(150, ErrorMessage = "El campo confirmación de contraseña puede contener como máximo 150 caracteres" )]
        [Compare(nameof(Contrasena), ErrorMessage = "El campo confirmación de contraseña debe coincidir con el campo contraseña")]
        public string ConfirmarContrasena { get; set; }
    }
}