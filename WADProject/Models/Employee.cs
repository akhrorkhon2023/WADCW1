namespace WADProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = default!;
    }
}
