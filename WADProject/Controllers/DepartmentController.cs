using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WADProject.Interfaces;
using WADProject.Models;
using WADProject.ViewModel;

namespace WADProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            var departments = _mapper.Map<List<DepartmentViewModel>>(_departmentRepository.GetAll());
            if (ModelState.IsValid)
            {
                return Ok(departments);
            }
            else return BadRequest(ModelState);
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get(int id)
        {
            var department = _mapper.Map<DepartmentViewModel>(_departmentRepository.GetDepartment(id));
            if (ModelState.IsValid)
            {
                return Ok(department);
            }
            else return BadRequest(ModelState);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Create([FromBody] DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }  
            var createdDepartment = _mapper.Map<Department>(departmentViewModel);
            if (!_departmentRepository.CreateDepartment(createdDepartment))
            {
                return BadRequest(ModelState);
            }
            return Ok("Created");

        }
        [HttpPut]
        [ProducesResponseType(200)]
        public IActionResult Update(int departmentId, [FromBody] DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = _departmentRepository.GetDepartment(departmentId);
            if(department == null)
            {
                return NotFound();
            }
            if(department.Id != departmentViewModel.Id)
            {
                return BadRequest(ModelState);
            }
            var updatedDepartment = _mapper.Map<Department>(departmentViewModel);
            if (!_departmentRepository.UpdateDepartment(updatedDepartment))
            {
                return BadRequest(ModelState);
            }
            return Ok("Updated");

        }
        [HttpDelete]
        [ProducesResponseType(200)]
        public IActionResult Delete(int id)
        {
            var departent = _departmentRepository.GetDepartment(id);
            if(departent == null)
            {
                return BadRequest(ModelState);
            }
            if (!_departmentRepository.DeleteDepartment(id))
            {
                return BadRequest(ModelState);
            }
            return Ok("Deleted");
        }
    }
}
