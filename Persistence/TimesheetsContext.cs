using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public class TimesheetsContext : IdentityDbContext<User> , ITimesheetsContext
    {
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<TimeCode> TimeCodes { get; set; }
        public IDbSet<Timesheet> Timesheets { get; set; }

        public TimesheetsContext()
            : base("TimesheetsContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // http://stackoverflow.com/questions/19460386/how-can-i-change-the-table-names-when-using-visual-studio-2013-aspnet-identity
            modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
