using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;

namespace TesteZDZ.Application.Interfaces
{
    public  interface IProductService
    {
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> AddProductAsync(CreateProductDto productDto);
        Task<ProductDto> UpdateProductAsync(Guid id, CreateProductDto productDto);
        Task<ProductDto> DeleteProductAsync(Guid id);
        Task<List<ProductDto>> SearchBySupplier(string nameSupplier);
    }
}
