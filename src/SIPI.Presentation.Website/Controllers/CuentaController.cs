using SIPI.Core.Controladores;
using SIPI.Core.Vistas;
using SIPI.Presentation.Website.Models.Cuenta;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;

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

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = _controladorCuenta.IniciarSesion(model.User, model.Password);

            if (usuario == null)
            {
                // Mostrar error de auth generico
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

        private ActionResult RedirectToHome()
        {
            return RedirectToAction("index", "home", new { area = "" });
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