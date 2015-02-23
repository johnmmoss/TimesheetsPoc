using System.Data.Entity;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public class TimesheetsContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TimeCode> TimeCodes { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}
