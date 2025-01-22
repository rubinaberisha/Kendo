namespace Kendo.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int? ReportsTo { get; set; } // Nullable to allow root-level nodes
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int Extension { get; set; }
        public string Address { get; set; }
    }
}
