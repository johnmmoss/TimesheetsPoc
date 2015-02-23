using System.Collections.Generic;

namespace TimesheetPoc.Domain
{
    public class Timesheet
    {
        public int Id { get; set; }
        public ICollection<TimesheetEntry> Entries { get; set; }
        public bool IsAuthorised { get; set; }
    }
}
