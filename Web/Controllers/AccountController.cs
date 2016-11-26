using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TimesheetPoc.Persistence;

namespace TimesheetPoc.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string email, string password, string returnUrl)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            var rememberMe = false;
            
            //if (ModelState.IsValid) // TODO:- Create a model
            {
                var user = await userManager.FindAsync(email, password);
                if (user != null)
                {
                    //authManager.SignOut(DefaultAuthenticationTypes.ExternalCookie); // In template code, but not SO example ???

                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    var properties = new AuthenticationProperties() {IsPersistent = rememberMe};
                    
                    authManager.SignIn(properties, userIdentity);
                    
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // TODO:- Want to redirect to the page we logged in on??? ReturnURl

            return RedirectToAction("Index", "Home");
        }

        /**
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                AppUser user = userManager.Find(login.UserName, login.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
         *
                    return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }
         * **/
    }
}