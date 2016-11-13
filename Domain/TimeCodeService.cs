using System;
using System.Collections.Generic;
using System.Linq;
using TimesheetPoc.Domain.Interfaces;
using TimesheetPoc.Persistence;

namespace TimesheetPoc.Domain
{
    public class TimeCodeService : ITimeCodeService
    {
        private readonly IUnitOfWork iUnitOfWork;

        public TimeCodeService(IUnitOfWork iUnitOfWork)
        {
            if (iUnitOfWork == null) throw new ArgumentNullException("iUnitOfWork");

            this.iUnitOfWork = iUnitOfWork;
        }

        public IList<TimeCode> GetAll()
        {
            return iUnitOfWork.TimeCodes.FindAll();
        }
        public TimeCode GetById(int id)
        {
            return iUnitOfWork.TimeCodes.FindBy(x => x.Id == id).FirstOrDefault();
        }

        public void Add(TimeCode timeCode)
        {
            iUnitOfWork.TimeCodes.Add(timeCode);
            iUnitOfWork.Save();
        }
        public void Delete(int id)
        {
            iUnitOfWork.TimeCodes.Delete(id);
            iUnitOfWork.Save();
        }
        public void Update(TimeCode timeCode)
        {
            iUnitOfWork.TimeCodes.Update(timeCode);
            iUnitOfWork.Save();
        }
    }
}
