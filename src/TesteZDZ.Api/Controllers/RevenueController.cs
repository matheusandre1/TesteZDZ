using Microsoft.AspNetCore.Mvc;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Application.Services;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;

        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }

        [HttpPost("createRevenue")]
        public async Task<IActionResult> CreateRevenueAsync([FromBody] CreateRevenueDto revenueDto)
        {
            try
            {
                var revenue = await _revenueService.AddRevenueAsync(revenueDto);

                return Ok(revenue);
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
                var revenue = await _revenueService.GetAllRevenueAsync();

                return Ok(revenue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("deleteById")]
        public async Task<IActionResult> DeleteById([FromBody] Guid id)
        {
            try
            {
                var revenue = await _revenueService.DeleteRevenueAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            try
            {
                var revenue = await _revenueService.GetByIdAsync(id);

                return Ok(revenue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRevenue([FromQuery] Guid id, CreateRevenueDto dto)
        {
            try
            {
                var updateRevenue = await _revenueService.UpdateRevenueAsync(id, dto);

                return Ok(updateRevenue);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }


        [HttpGet("getPaymentMethod")]
        public async Task<IActionResult> GetByPaymentMethod([FromQuery] PaymentMethod paymentMethod)
        {
            try
            {
                var payment = await _revenueService.SearchByPaymentMethod(paymentMethod);

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
