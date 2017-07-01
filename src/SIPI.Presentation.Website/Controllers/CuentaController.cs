using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Models.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    public class CuentaController : Controller
    {
        private readonly CuentaControlador _controladorCuenta;

        public CuentaController(CuentaControlador controladorCuenta)
        {
            _controladorCuenta = controladorCuenta;
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        // what do we need here?
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                // EX

            //var c = new CuentaControlador();

            _controladorCuenta.IniciarSesion(model.User, model.Password);
            //var result = new CuentaControlador().Login(model.User, model.Password);

            //...

            return null;
        }
    }
}