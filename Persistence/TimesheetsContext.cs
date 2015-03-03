using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public interface ITimesheetsContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<TimeCode> TimeCodes { get; set; }
        DbSet<Timesheet> Timesheets { get; set; }
        
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        void Dispose();
    }

    public class TimesheetsContext : DbContext, ITimesheetsContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TimeCode> TimeCodes { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}
