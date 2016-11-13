using System;
using System.Collections.Generic;
using System.Linq;
using TimesheetPoc.Domain;
using TimesheetPoc.Domain.Interfaces;
using TimesheetPoc.Persistence;

namespace TimesheetPoc.Domain
{
    public class DepartmentService : IDepartmentService
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
        public Department GetById(int id)
        {
            return iUnitOfWork.Departments.FindBy(x => x.Id == id).FirstOrDefault();
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
