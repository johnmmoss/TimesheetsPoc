using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace Domain.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private TimesheetsContext context;

        public UnitOfWork()
        {
            context = new TimesheetsContext();
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
