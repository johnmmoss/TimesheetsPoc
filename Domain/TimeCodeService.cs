using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetPoc.Domain;

namespace Domain
{
    public class TimeCodeService
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
        public TimeCode GetTimeCodeByName(string name)
        {
            return iUnitOfWork.TimeCodes.FindBy(x => x.Name == name).FirstOrDefault();
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
