using TimesheetPoc.Persistence;

namespace AcceptanceTests.Data
{
    public class DatabaseHelper
    {
        public static void TearDown()
        {
            // Code to empty the database tables
            DeleteAndReseed("Departments");
        }

        public static void Reset()
        {
            // Code to insert data ready for dev
        }

        private static void DeleteAndReseed(string tableName)
        {
            using (var context = new TimesheetsContext())
            {
                context.Database.ExecuteSqlCommand(string.Format("DELETE FROM dbo.[{0}] DBCC CHECKIDENT ('{0}', RESEED, 0)", tableName));
            }
        }
    }
}
