using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<Department> Departments { get; set; }
        IRepository<TimeCode> TimeCodes { get; set; }

        void Save();
    }
}