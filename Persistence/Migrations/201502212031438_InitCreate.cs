namespace TimesheetPoc.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Forename = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timesheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAuthorised = c.Boolean(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.TimesheetEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TimeSpent = c.Int(nullable: false),
                        TimeCode_Id = c.Int(),
                        Timesheet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeCodes", t => t.TimeCode_Id)
                .ForeignKey("dbo.Timesheets", t => t.Timesheet_Id)
                .Index(t => t.TimeCode_Id)
                .Index(t => t.Timesheet_Id);
            
            CreateTable(
                "dbo.TimeCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timesheets", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.TimesheetEntries", "Timesheet_Id", "dbo.Timesheets");
            DropForeignKey("dbo.TimesheetEntries", "TimeCode_Id", "dbo.TimeCodes");
            DropIndex("dbo.TimesheetEntries", new[] { "Timesheet_Id" });
            DropIndex("dbo.TimesheetEntries", new[] { "TimeCode_Id" });
            DropIndex("dbo.Timesheets", new[] { "Employee_Id" });
            DropTable("dbo.TimeCodes");
            DropTable("dbo.TimesheetEntries");
            DropTable("dbo.Timesheets");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
