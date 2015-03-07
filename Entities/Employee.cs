using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimesheetPoc.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Timesheet> Timesheets { get; set; }
    }
}
