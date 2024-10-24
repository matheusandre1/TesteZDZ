using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Application.Interfaces
{
    public  interface IProductService
    {
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> AddAsync(ProductDto entity);
        Task<ProductDto> UpdateAsync(Guid id, ProductDto entity);
        Task<ProductDto> DeleteAsync(Guid id);
        Task<List<ProductDto>> SearchBySupplier(string nameSupplier);
    }
}
