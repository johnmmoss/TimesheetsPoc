using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public interface ITimesheetsContext
    {
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Department> Departments { get; set; }
        IDbSet<TimeCode> TimeCodes { get; set; }
        IDbSet<Timesheet> Timesheets { get; set; }
        
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        void Dispose();
        DbSet<T> Set<T>() where T : class;
    }
}