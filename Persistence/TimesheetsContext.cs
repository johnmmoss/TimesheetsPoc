using System.Data.Entity;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public class TimesheetsContext : DbContext, ITimesheetsContext
    {
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<TimeCode> TimeCodes { get; set; }
        public IDbSet<Timesheet> Timesheets { get; set; }
    }
}
