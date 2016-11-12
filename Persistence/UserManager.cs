using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    //http://stackoverflow.com/questions/31960433/adding-asp-net-mvc5-identity-authentication-to-an-existing-project
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static UserManager Create(
            IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(
                new UserStore<User>(context.Get<TimesheetsContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }

}
