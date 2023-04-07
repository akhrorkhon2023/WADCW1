using AutoMapper;
using WADProject.Models;
using WADProject.ViewModel;

namespace WADProject.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();
        }
    }
}
