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
        public ActionResult Index()
        {
            using (var context = new TimesheetsContext())
            {
                var users = context.Users.ToList().Select(x =>
                    new UserModel
                    {
                        Id = x.Id,
                        Firstname = x.Firstname,
                        Surname = x.Surname,
                        Email = x.Email,
                        IsCurrentUser = x.Email == User.Identity.Name
                    });

                return View(users.AsEnumerable());
            }
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