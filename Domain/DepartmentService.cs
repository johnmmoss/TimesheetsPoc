using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DepartmentService
    {
        private readonly IUnitOfWork iUnitOfWork;

        public DepartmentService(IUnitOfWork iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork;
        }
    }
}
