namespace WADProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public IList<Employee> Employees { get; set; } = default!;
    }
}
