using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace TimesheetsPoc.Domain.UnitTests
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public bool SaveWasCalled;

        public IRepository<Department> Departments { get; private set; }
        public IRepository<TimeCode> TimeCodes { get; private set; }

        public FakeUnitOfWork()
        {
            Departments = new FakeDepartmentRepository();
            TimeCodes = new FakeRepository<TimeCode>();

            SaveWasCalled = false;
        }

        public void Save()
        {
            SaveWasCalled = true;
        }
    }
}