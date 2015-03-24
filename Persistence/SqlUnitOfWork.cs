using Domain;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private ITimesheetsContext context;

        public SqlUnitOfWork(ITimesheetsContext context)
        {
            this.context = context;
        }

        private SqlRepository<Department> departments;
        public IRepository<Department> Departments
        {
            get
            {
                if (departments == null)
                {
                    departments = new SqlRepository<Department>(context);
                }
                return departments;
            }
        }

        private SqlRepository<TimeCode> timeCodes; 
        public IRepository<TimeCode> TimeCodes
        {
            get
            {
                if (timeCodes == null)
                {
                    timeCodes = new SqlRepository<TimeCode>(context);
                }
                return timeCodes;
            }
        }
        
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
