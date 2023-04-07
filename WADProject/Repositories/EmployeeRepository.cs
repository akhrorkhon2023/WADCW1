using WADProject.Constants;
using WADProject.Interfaces;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConstant _dbConstant;

        public EmployeeRepository(DbConstant dbConstant)
        {
            _dbConstant = dbConstant;
        }
        public bool CreateEmployee(Employee employee)
        {
            _dbConstant.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _dbConstant.Employees.Where(e => e.Id == id).FirstOrDefault();
            _dbConstant.Employees.Remove(employee);
            return Save();
        }

        public IList<Employee> GetAll()
        {
            return _dbConstant.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _dbConstant.Employees.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _dbConstant.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _dbConstant.Update(employee);
            return Save();

        }
    }
}
