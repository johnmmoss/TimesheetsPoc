using System;

namespace TimesheetPoc.Domain
{
    public class TimesheetEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeCode TimeCode { get; set; }
        public int TimeSpent { get; set; }
    }
}
