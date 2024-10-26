using Microsoft.AspNetCore.Mvc;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Application.Services;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }


        [HttpPost("createExpense")]

        public async Task<IActionResult> CreateExpenseAsync([FromBody] CreateExpenseDto expenseDto)
        {
            try
            {
                if (expenseDto == null)
                {
                    return BadRequest("Dados Invalidos");
                }

                var newEmployee = await _expenseService.CreateExpenseAsync(expenseDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetExpenseById([FromQuery] Guid id)
        {
            try
            {


                var newEmployee = await _expenseService.GetByIdAsync(id);

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetExpenseAll()
        {
            try
            {
                var expenses = await _expenseService.GetAllExpenseAsync();

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("deletebyId")]
        public async Task<IActionResult> DeleteById([FromQuery] Guid id)
        {
            try
            {
                var expense = await _expenseService.DeleteExpenseAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee([FromQuery] Guid id,  CreateExpenseDto dto)
        {
            try
            {
                var updateExpense = await _expenseService.UpdateExpenseAsync(id, dto);

                return Ok(updateExpense);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpGet("byCategory")]
        public async Task<IActionResult> GetByCategory([FromQuery] Category category)
        {
            try
            {
                var getCategory = await _expenseService.SearchExpenseByCategory(category);

                return Ok(getCategory);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byPaymentMethod")]
        public async Task<IActionResult> GetByPaymentMethod([FromQuery] PaymentMethod paymentMethod)
        {
            try
            {
                var payment = await _expenseService.SearchExpenseByPaymentMethod(paymentMethod);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
