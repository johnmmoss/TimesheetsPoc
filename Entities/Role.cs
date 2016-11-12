using Microsoft.AspNet.Identity.EntityFramework;

namespace TimesheetPoc.Domain
{
    public class Role : IdentityRole
    {
        public Role() : base() { }
        public Role(string name) : base(name) { }
    }
}
