using EmployeeAPI.Model;
using EmployeeAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employeeList")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("getByemployeeId/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        [HttpPost("addEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Valid employee data is required.");

            if (string.IsNullOrWhiteSpace(employee.FullName) || employee.FullName.Trim().ToLower() == "string")
                return BadRequest("Employee fullname is required.");
            else if (string.IsNullOrWhiteSpace(employee.Department) || employee.Department.Trim().ToLower() == "string")
                return BadRequest("Employee department is required.");
            else if (employee.Salary <= 0)
                return BadRequest("Employee salary is required.");

            var addedEmployee = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployee.EmployeeId }, addedEmployee);
        }

        [HttpPut("updateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (updatedEmployee == null || string.IsNullOrWhiteSpace(updatedEmployee.FullName) ||
                string.IsNullOrWhiteSpace(updatedEmployee.Department) || updatedEmployee.Salary <= 0)
            {
                return BadRequest("Valid updated employee data is required.");
            }

            var employee = _employeeService.UpdateEmployee(id, updatedEmployee);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        [HttpDelete("deleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var isDeleted = _employeeService.DeleteEmployee(id);
            if (!isDeleted)
                return NotFound($"Employee with ID {id} not found.");

            return NoContent();
        }
    }
}
