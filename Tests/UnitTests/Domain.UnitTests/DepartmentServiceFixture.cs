using NUnit.Framework;
using Rhino.Mocks;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace TimesheetsPoc.Domain.UnitTests
{
    public class DepartmentServiceFixture
    {
        private DepartmentService service;
        private IUnitOfWork mockUnitOfWork;
        private IRepository<Department> mockDepartmentsRepostiory;

        [SetUp]
        public void SetUp()
        {
            mockUnitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            mockDepartmentsRepostiory = MockRepository.GenerateMock<IRepository<Department>>();
            mockUnitOfWork.Stub(x => x.Departments).Return(mockDepartmentsRepostiory);

            service = new DepartmentService(mockUnitOfWork);
        }

        [Test]
        public void Add_AddsANewDepartment()
        {
            service.Add(new Department());

            mockDepartmentsRepostiory.AssertWasCalled(x => x.Add(Arg<Department>.Is.Anything));
            mockUnitOfWork.AssertWasCalled(x => x.Save(), x => x.Repeat.Once());
        }

        [Test]
        public void Delete_DeletesADepartment()
        {
            service.Delete(7);

            mockDepartmentsRepostiory.AssertWasCalled(x => x.Delete(Arg<int>.Is.Equal(7)));
            mockUnitOfWork.AssertWasCalled(x => x.Save(), x => x.Repeat.Once());
        }

        [Test]
        public void Update_UpdatesADepartment()
        {
            service.Update(new Department());

            mockDepartmentsRepostiory.AssertWasCalled(x => x.Update(Arg<Department>.Is.Anything));
            mockUnitOfWork.AssertWasCalled(x => x.Save(), x => x.Repeat.Once());
        }
    }
}
