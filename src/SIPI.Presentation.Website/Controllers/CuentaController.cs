using SIPI.Core.Controladores;
using SIPI.Core.Vistas;
using SIPI.Presentation.Website.Models.Cuenta;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SIPI.Presentation.Website.Controllers
{
    public class CuentaController : BaseController
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
                ModelState.AddModelError("", "El usuario o contraseña ingresados son inválidos");
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

            _controladorCuenta.RecuperarContrasena(
                model.Email,
                hash => RenderViewToString(
                    "RecuperoMail",
                    new RecuperoMailModel(HttpServerUtility.UrlTokenEncode(hash))));

            // TODO: Show on layout
            TempData.Add("Notification", "Se envió un mail de recupero de contraseña al mail ingresado");

            return RedirectToHome();
        }

        [HttpGet]
        public ActionResult RecuperoConfirmar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperoConfirmar(RecuperoConfirmarModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var esValido = _controladorCuenta.RecuperarContrasena(
                model.Email, model.Contrasena, HttpServerUtility.UrlTokenDecode(model.Token));

            if (!esValido)
            {
                ModelState.AddModelError("", "El usuario no existe o el token ingresado es inválido");
                return View(model);
            }

            return RedirectToHome();
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
    }
}