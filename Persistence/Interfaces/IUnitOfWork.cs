using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<Department> Departments { get; }
        IRepository<TimeCode> TimeCodes { get; }

        void Save();
    }
}