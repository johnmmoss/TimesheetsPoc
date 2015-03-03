﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TimesheetPoc.Domain;

namespace TimesheetPoc.Persistence
{
    public interface ITimesheetsContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<TimeCode> TimeCodes { get; set; }
        DbSet<Timesheet> Timesheets { get; set; }
        
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        void Dispose();
    }
}