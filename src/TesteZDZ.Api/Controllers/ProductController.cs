using Microsoft.AspNetCore.Mvc;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Application.Services;
using TesteZDZ.Domain.Repository;

namespace TesteZDZ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            try
            {
                var createProduct = await _productService.AddProductAsync(productDto);

                return Created();
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
                var expenses = await _productService.GetAllProductAsync();

                return Ok(expenses);
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
                var expense = await _productService.DeleteProductAsync(id);

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
                var expense = await _productService.GetByIdAsync(id);

                return Ok(expense);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee([FromQuery] Guid id, CreateProductDto dto)
        {
            try
            {
                var updateExpense = await _productService.UpdateProductAsync(id, dto);

                return Ok(updateExpense);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
            }
        }

        [HttpGet("GetSearchBySupplier")]
        public async Task<IActionResult> GetSearchBySupplier([FromQuery] string supplier)
        {
            try
            {
                var getSupplier = await _productService.SearchBySupplier(supplier);

                return Ok(getSupplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}