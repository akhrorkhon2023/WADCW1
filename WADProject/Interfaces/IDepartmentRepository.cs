using WADProject.Models;

namespace WADProject.Interfaces
{
    public interface IDepartmentRepository
    {
        IList<Department> GetAll();
        Department GetDepartment(int id);
        bool CreateDepartment(Department department);
        bool DeleteDepartment(int id);
        bool UpdateDepartment(Department department);
        bool Save();
    }
}
