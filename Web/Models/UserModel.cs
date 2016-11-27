namespace TimesheetPoc.Web.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public string PhoneNumber { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsCurrentUser { get; set; }
        public bool IsLockedOut { get; set; }
    }
}