using SIPI.Core.Controladores;
using SIPI.Core.Vistas;
using SIPI.Presentation.Website.Models.Cuenta;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System;
using SIPI.Core.Data.DTO;
using SIPI.Presentation.Website.Models.Shared;
using System.Collections.Generic;
using SIPI.Presentation.Website.Authentication;
using System.Web.Script.Serialization;

namespace SIPI.Presentation.Website.Controllers
{
    public class CuentaController : BaseController, IRecuperoMailBuilder
    {
        private readonly ControladorCuentas _controladorCuenta;

        public CuentaController(ControladorCuentas controladorCuenta)
        {
            _controladorCuenta = controladorCuenta;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = _controladorCuenta.IniciarSesion(model.Email, model.Contrasena);

            if (usuario == null)
            {
                TempData.Add("Error-Notifications-Login", "El usuario o contraseña ingresados son inválidos");
                return View(model);
            }

            Authenticate(usuario);

            if (usuario.SoyOperador())
            {
                return RedirectToAction("index", "pedidos", new { area = "admin" });
            }
            else if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToHome();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            if (Request.UrlReferrer != null && Url.IsLocalUrl(Request.UrlReferrer.ToString()))
                return Redirect(Request.UrlReferrer.ToString());

            return RedirectToHome();
        }

        [HttpGet]
        public ActionResult Recupero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recupero(RecuperoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _controladorCuenta
                .RecuperarContrasena(model.Email, model.Contrasena, this);

            // TODO: Show on layout
            TempData.Add("Notification", "Se envió un mail de recupero de contraseña al mail ingresado");

            return RedirectToHome();
        }

        [HttpGet]
        public ActionResult RecuperoConfirmar(RecuperoConfirmarModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToHome();

            _controladorCuenta
                .RecuperarContrasena(model.Email, HttpServerUtility.UrlTokenDecode(model.Token));

            return RedirectToHome();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Index(IndexFiltersModel filters)
        {
            return View(new IndexModel { Filters = filters });
        }

        // TODO: PRUEBA DE CONCEPTO - BORRAME!!
        // POR CONVENCION LAS TABLAS VAN A SER: <Action_Original>Table, por eso este es IndexTable
        [HttpGet]
        public ActionResult IndexTable(IndexFiltersModel filters, OffsetParams offsetParams)
        {
            return Json(
                _controladorCuenta.BuscarUsuarios(filters.Nombre, filters.Apellido, offsetParams.Offset, offsetParams.Limit), 
                JsonRequestBehavior.AllowGet);
        }

        private void Authenticate(UsuarioView usuario)
        {
            var identity = new GenericIdentity($"{usuario.Nombre} {usuario.Apellido}");

            string[] roles;
            if (usuario.SoyOperador())
            {
                roles = (usuario as OperadorView)
                    .Roles.Select(x => x.Nombre).ToArray();
            }
            else
            {
                roles = new[] { "Miembro" };
            }

            var data = new CustomPrincipalData()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Roles = roles
            };

            var userData = new JavaScriptSerializer().Serialize(data);
            var ticket = new FormsAuthenticationTicket(1, usuario.Email, DateTime.Now, DateTime.Now.AddDays(7), false, userData);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
        }

        public string RecuperoMailBody(UsuarioView usuario, byte[] hash)
        {
            return RenderViewToString(
                "RecuperoMail",
                new RecuperoMailModel(usuario.Email, HttpServerUtility.UrlTokenEncode(hash), usuario.Nombre, usuario.Apellido));
        }
    }
}