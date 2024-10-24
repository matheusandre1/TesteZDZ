using AutoMapper;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Domain.Repository;

namespace TesteZDZ.Application.Services
{
    public  class ProductService : IProductService
    {
       private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
         }

        public Task<ProductDto> AddAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> SearchBySupplier(string nameSupplier)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateAsync(Guid id, ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
