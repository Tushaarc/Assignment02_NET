using AutoMapper;
using EmpMngmntSys.Contracts;
using EmpMngmntSys.DTOs.Employee;
using EmpMngmntSys.Models;
using EmpMngmntSys.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpMngmntSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this._mapper = mapper;
            this._employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<List<EmployeeDto>>> GetAllEmployees()
        {
            var employees = await this._employeeRepository.GetAllAsync();
            var records = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(records);
        }

        [HttpGet("GetEmployee")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
        {
            var employee = await this._employeeRepository.GetAsync(employeeId);

            if (employee == null)
            {
                throw new Exception($"EmployeeID {employeeId} is not found.");
            }

            var EmployeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(EmployeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<Employees>> CreateEmployee(EmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employees>(createEmployeeDto);

            await this._employeeRepository.CreateAsync(employee);

            return CreatedAtAction("GetEmployee", new { id = employee.EId }, employee);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, EmployeeDto updateEmployeeDto)
        {
            if (employeeId != updateEmployeeDto.EId)
            {
                return BadRequest("Invalid Department Id");
            }

            var employee = await _employeeRepository.GetAsync(employeeId);

            if (employee == null)
            {
                throw new Exception($"EployeeID {employeeId} is not found.");
            }
            _mapper.Map(updateEmployeeDto, employee);

            try
            {
                await _employeeRepository.UpdateAsync(employee);
            }
            catch (Exception)
            {
                throw new Exception($"Error occured while updating EmployeeID {employeeId}.");
            }

            return NoContent();
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _employeeRepository.DeleteAsync(employeeId);
            return NoContent();
        }



    }
}
