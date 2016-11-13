using System.Collections.Generic;

namespace TimesheetPoc.Domain.Interfaces
{
    public interface IDepartmentService
    {
        IList<Department> GetAll();
        Department GetById(int code);
        void Add(Department department);
        void Delete(int id);
        void Update(Department department);
    }
}