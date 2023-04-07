using WADProject.Models;

namespace WADProject.Interfaces
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetAll();
        Employee GetEmployee(int id);
        bool CreateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        bool UpdateEmployee( Employee employee);
        bool Save();
    }
}
