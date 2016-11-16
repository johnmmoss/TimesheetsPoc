using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;
using TimesheetPoc.Web.Models;

namespace TimesheetPoc.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            //var signInManager = HttpContext.GetOwinContext().Get<SignInManager<User, string>>(); // ???

            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authManager.SignIn(new AuthenticationProperties {IsPersistent = false}, identity);

                    return Redirect("Index");
                }
                else
                {
                    ModelState.AddModelError("AuthenticationError", result.Errors.First());
                }
            }

            return View();
        }
    }
}