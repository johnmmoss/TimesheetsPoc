using TimesheetPoc.Domain;
using TimesheetPoc.Persistence.Domain;

namespace TimesheetPoc.Persistence
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private ITimesheetsContext context;

        public SqlUnitOfWork(ITimesheetsContext context)
        {
            this.context = context;
        }

        private IRepository<Department> departments;
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
            set { departments = value; }
        }

        private IRepository<TimeCode> timeCodes; 
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
            set { timeCodes = value; }
        }
        
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
