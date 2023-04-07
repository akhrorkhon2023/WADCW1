
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WADProject.Interfaces;
using WADProject.Models;
using WADProject.ViewModel;

namespace WADProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            var employees = _mapper.Map<List<EmployeeViewModel>>(_employeeRepository.GetAll().ToList());
            if(ModelState.IsValid)
            {
                return Ok(employees);
            }
            return BadRequest(ModelState);

        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get(int id)
        {
            var employee = _mapper.Map<EmployeeViewModel>(_employeeRepository.GetEmployee(id));
            if(ModelState.IsValid)
            {
                return Ok(employee);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create(int departmentId, [FromBody] EmployeeViewModel employeeViewModel)
        {
            var createdEmployee = _mapper.Map<Employee>(employeeViewModel);
            createdEmployee.DepartmentId = departmentId;
            if (!_employeeRepository.CreateEmployee(createdEmployee))
            {
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                return Ok("Created");
            }
            return BadRequest("Failed");
        }
        [HttpPut]
        [ProducesResponseType(200)]
        public IActionResult Update(int departmentId, int employeeId, [FromBody] EmployeeViewModel employeeViewModel)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(employeeViewModel.Id != employeeId)
            {
                return NotFound();
            }
            var updatedEmployee = _mapper.Map<Employee>(employeeViewModel);
            updatedEmployee.DepartmentId = departmentId;
            if (!_employeeRepository.UpdateEmployee(updatedEmployee))
            {
                return BadRequest();
            }
            return Ok("Updated");
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if(employee == null) 
                return BadRequest(ModelState);
            if (!_employeeRepository.DeleteEmployee(id))
            {
                return BadRequest(ModelState);
            }
            return Ok("Deleted");
        }

    }
}
