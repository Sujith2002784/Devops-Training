using EmployeeDetails.Models;
using EmployeeDetails.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("corsapp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet] public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        { 
            var employees = await _employeeRepository.GetAllEmployeesAsync(); 
            return Ok(employees); 
        }

        [HttpGet("department/{departmentName}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByDepartmentName(string departmentName)
        {
            var employees = await _employeeRepository.GetEmployeesByDepartmentNameAsync(departmentName);
            if (employees == null || !employees.Any())
            {
                return NotFound();
            }
            return Ok(employees);
        }
        [HttpGet("Id")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeDto employeeDto)
        {
            var newEmployee = await _employeeRepository.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
    
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] NewEmpDto updatedEmployeeDto)
        {
            try
            {
                var existingEmployee = await _employeeRepository.UpdateEmployeeAsync(id, updatedEmployeeDto);
                if (existingEmployee == null)
                {
                    return NotFound();
                }
                return Ok(existingEmployee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deletedEmployee = await _employeeRepository.DeleteEmployeeAsync(id);
            if (deletedEmployee == null)
            {
                return NotFound();
            }
            return Ok(new { message = $"Employee {deletedEmployee.EmpName} has been deleted successfully." });
        }
    }
}
