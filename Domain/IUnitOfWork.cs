using TimesheetPoc.Domain;

namespace Domain
{
    public interface IUnitOfWork
    {
        IRepository<Department> Departments { get; }
        IRepository<TimeCode> TimeCodes { get; }

        void Save();
    }
}