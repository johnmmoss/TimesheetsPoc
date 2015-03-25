using System.Linq;
using TimesheetPoc.Domain;

namespace TimesheetsPoc.Domain.UnitTests
{
    public class FakeDepartmentRepository : FakeRepository<Department>
    {
        public override Department FindById(int id)
        {
            return _set.First(x => x.Id == id);
        }

        public override void Delete(int id)
        {
            var entity = FindById(id);
            Delete(entity);
        }
    }
}