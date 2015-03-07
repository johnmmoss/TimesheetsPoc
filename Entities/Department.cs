using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimesheetPoc.Domain
{
    public class Department
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        ICollection<Employee> Employees { get; set; }
        ICollection<TimeCode> TimeCodes { get; set; } 
    }
}
