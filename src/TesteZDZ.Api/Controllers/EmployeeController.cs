using Microsoft.AspNetCore.Mvc;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;

namespace TesteZDZ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("createEmployee")]

        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto employeeDto)
        {
            try
            {
                if (employeeDto == null)
                {
                    return BadRequest("Dados Invalidos");
                }

                var newEmployee = await _employeeService.CreateEmployeeAsync(employeeDto);

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] Guid id)
        {
            try
            {


                var newEmployee = await _employeeService.GetEmployeeByIdAsync(id);

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetEmployeeAll()
        {
            try
            {
                var newEmployee = await _employeeService.GetAllAsync();

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("getByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            try
            {
                var employee = await _employeeService.SearchEmployeeByName(name);

                if (employee == null)
                {
                    return NotFound();
                }


                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletebyId")]
        public async Task<IActionResult> DeleteById([FromBody] Guid id)
        {
            try
            {
                var employee = await _employeeService.DeleteEmployeeAsync(id);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromQuery] CreateEmployeeDto dto)
        {
            try
            {
                var updateEmployee = await _employeeService.UpdateEmployeeAsync(id, dto);

                return Ok(updateEmployee);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }

        }
    }
}
