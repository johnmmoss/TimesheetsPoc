using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetPoc.Domain;

namespace Domain
{
    public class DepartmentService
    {
        private readonly IUnitOfWork iUnitOfWork;

        public DepartmentService(IUnitOfWork iUnitOfWork)
        {
            if (iUnitOfWork == null) throw new ArgumentNullException("iUnitOfWork");

            this.iUnitOfWork = iUnitOfWork;
        }

        public IList<Department> GetAll()
        {
            return iUnitOfWork.Departments.FindAll();
        }
        public Department GetDepartmentByCode(string code)
        {
            return iUnitOfWork.Departments.FindBy(x => x.Code == code).FirstOrDefault();
        }

        public void Add(Department department)
        {
            iUnitOfWork.Departments.Add(department);
            iUnitOfWork.Save();
        }
        public void Delete(int id)
        {
            iUnitOfWork.Departments.Delete(id);
            iUnitOfWork.Save();
        }
        public void Update(Department department)
        {
            iUnitOfWork.Departments.Update(department);
            iUnitOfWork.Save();
        }
    }
}
