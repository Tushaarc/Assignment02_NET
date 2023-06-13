using AutoMapper;
using EmpMngmntSys.Contracts;
using EmpMngmntSys.DTOs.Department;
using EmpMngmntSys.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpMngmntSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            this._mapper = mapper;
            this._departmentRepository = departmentRepository;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult<List<GetDepartmentDto>>> GetAllDepartments()
        {
            var departments = await this._departmentRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDepartmentDto>>(departments);
            return Ok(records);
        }

        [HttpGet("GetDepartment")]
        public async Task<ActionResult<GetDepartmentDto>> GetDepartment(int departmentId)
        {
            var department = await this._departmentRepository.GetAsync(departmentId);

            if (department == null)
            {
                throw new Exception($"DepartmentID {departmentId} is not found.");
            }

            var DepartmentDto = _mapper.Map<GetDepartmentDto>(department);

            return Ok(DepartmentDto);
        }

        [HttpPost]
        public async Task<ActionResult<Departments>> CreateDepartment(GetDepartmentDto createDepartmentDto)
        {
            var department = _mapper.Map<Departments>(createDepartmentDto);

            await this._departmentRepository.CreateAsync(department);

            return CreatedAtAction("GetDepartment", new { id = department.DId }, department);
        }

        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(int departmentId, UpdateDepartmentDto updateDepartmentDto)
        {
            if (departmentId != updateDepartmentDto.DId)
            {
                return BadRequest("Invalid Department Id");
            }

            var department = await _departmentRepository.GetAsync(departmentId);

            if (department == null)
            {
                throw new Exception($"DepartmentID {departmentId} is not found.");
            }

            _mapper.Map(updateDepartmentDto, department);

            try
            {
                await _departmentRepository.UpdateAsync(department);
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating DepartmentID {departmentId}.");
            }

            return NoContent();
        }

        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            await _departmentRepository.DeleteAsync(departmentId);
            return NoContent();
        }

    }
}
