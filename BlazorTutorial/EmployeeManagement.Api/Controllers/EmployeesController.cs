using EmployeeManagement.Api.Models;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("search/{name}/{gender?}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
               var result = await _employeeRepository.Search(name, gender);

                if(!result.Any())
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);

                if(result is null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if(employee is null)
                {
                    return BadRequest();
                }

                var existingEmployee = await _employeeRepository.GetEmployeeByEmail(employee.Email);

                if(existingEmployee is not null) 
                {

                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await _employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId}, createdEmployee);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if(employee.EmployeeId != id)
                {
                    return BadRequest("Employee Id mismatch");
                }

                var employeToUpdatee = await _employeeRepository.GetEmployee(id);

                if(employeToUpdatee is null)
                {
                    return NotFound($"Employee with id = {id} not found");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employeeToRemove = await _employeeRepository.GetEmployee(id);

                if(employeeToRemove is null)
                {
                    return NotFound($"No employee with id = {id} was found");
                }

                await _employeeRepository.DeleteEmployee(id);

                return Ok($"Emploee with id = {id} was succesfully deleted");

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
