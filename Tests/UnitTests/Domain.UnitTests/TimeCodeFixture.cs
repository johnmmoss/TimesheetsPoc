using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace TimesheetsPoc.Domain.UnitTests
{
    public class TimeCodeFixture
    {
        private TimeCodeService service;
        private IUnitOfWork mockUnitOfWork;
        private IRepository<TimeCode> mockTimeCodesRepostiory;

        [SetUp]
        public void SetUp()
        {
            mockUnitOfWork = MockRepository.GenerateMock<IUnitOfWork>();
            mockTimeCodesRepostiory = MockRepository.GenerateMock<IRepository<TimeCode>>();
            mockUnitOfWork.Stub(x => x.TimeCodes).Return(mockTimeCodesRepostiory);

            service = new TimeCodeService(mockUnitOfWork);
        }

        [Test]
        public void Add_AddsANewTimeCode()
        {
            service.Add(new TimeCode());

            mockTimeCodesRepostiory.AssertWasCalled(x => x.Add(Arg<TimeCode>.Is.Anything));
            mockUnitOfWork.AssertWasCalled(x => x.Save(), x => x.Repeat.Once());
        }

        [Test]
        public void Delete_DeletesATimeCode()
        {
            service.Delete(7);

            mockTimeCodesRepostiory.AssertWasCalled(x => x.Delete(Arg<int>.Is.Equal(7)));
            mockUnitOfWork.AssertWasCalled(x => x.Save(), x => x.Repeat.Once());
        }

        [Test]
        public void Update_UpdatesATimeCode()
        {
            service.Update(new TimeCode());

            mockTimeCodesRepostiory.AssertWasCalled(x => x.Update(Arg<TimeCode>.Is.Anything));
            mockUnitOfWork.AssertWasCalled(x => x.Save(), x => x.Repeat.Once());
        }

    }
}
