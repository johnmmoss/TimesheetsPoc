using System.Collections.Generic;

namespace TimesheetPoc.Domain.Interfaces
{
    public interface ITimeCodeService
    {
        IList<TimeCode> GetAll();
        TimeCode GetById(int id);
        void Add(TimeCode timeCode);
        void Delete(int id);
        void Update(TimeCode timeCode);
    }
}