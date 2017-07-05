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

namespace SIPI.Presentation.Website.Controllers
{
    public class CuentaController : BaseController, IRecuperoMailBuilder
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
                return RedirectToAction("index", "home", new { area = "admin" });
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
        public ActionResult Index()
        {
            return View();
        }


        // TODO: PRUEBA DE CONCEPTO - BORRAME!!
        [HttpGet]
        public ActionResult _Table(OffsetParams offsetParams)
        {
            return Json(
                _controladorCuenta.BuscarUsuarios(offsetParams), 
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

            var principal = new GenericPrincipal(identity, roles);
            HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;
            FormsAuthentication.SetAuthCookie(usuario.Email, createPersistentCookie: true);
        }

        public string RecuperoMailBody(UsuarioView usuario, byte[] hash)
        {
            return RenderViewToString(
                "RecuperoMail",
                new RecuperoMailModel(usuario.Email, HttpServerUtility.UrlTokenEncode(hash), usuario.Nombre, usuario.Apellido));
        }


        //public class PageParams
        //{
        //    public enum SortOrder
        //    {
        //        asc,
        //        desc
        //    }

        //    public SortOrder Order { get; set; }

        //    public string Sort { get; set; }

        //    public string Search { get; set; }

        //    public int Offset { get; set; }

        //    public int Limit { get; set; }
        //}
    }
}