using NUnit.Framework;
using TimesheetPoc.Domain;

namespace TimesheetsPoc.Domain.UnitTests
{
    public class DepartmentServiceFixture
    {
        private DepartmentService service;

        [Test]
        public void Add_AddsANewDepartment()
        {
            var fakeUnitOfWork = new FakeUnitOfWork();
            service = new DepartmentService(fakeUnitOfWork);

            service.Add(new Department());

            Assert.IsTrue(fakeUnitOfWork.SaveWasCalled);
            Assert.That(fakeUnitOfWork.Departments.FindAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void Delete_DeletesADepartment()
        {
            var department = new Department()
                {
                    Id = 7,
                    Code = "ENG001",
                    Name = "Department1"
                };

            var fakeUnitOfWork = new FakeUnitOfWork();
            service = new DepartmentService(fakeUnitOfWork);
            fakeUnitOfWork.Departments.Add(department);

            service.Delete(7);

            Assert.IsTrue(fakeUnitOfWork.SaveWasCalled);
            Assert.That(fakeUnitOfWork.Departments.FindAll().Count, Is.EqualTo(0));
        }
    }
}
