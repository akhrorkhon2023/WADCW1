using WADProject.Constants;
using WADProject.Interfaces;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConstant _dbConstant;

        public DepartmentRepository(DbConstant dbConstant)
        {
            _dbConstant = dbConstant;
        }
        public bool CreateDepartment(Department department)
        {
            _dbConstant.Add(department);
            return Save();
        }

        public bool DeleteDepartment(int id)
        {
            var dep = _dbConstant.Departments.Where(x => x.Id == id).FirstOrDefault();
            _dbConstant.Remove(dep);
            return Save();
        }

        public IList<Department> GetAll()
        {
            return _dbConstant.Departments.ToList();
        }

        public Department GetDepartment(int id)
        {
            return _dbConstant.Departments.Where(d => d.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _dbConstant.SaveChanges();
            return saved > 0;
        }

        public bool UpdateDepartment(Department department)
        {
            _dbConstant.Update(department);
            return Save();  
        }
    }
}
