using AutoMapper;
using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Repository;

namespace TesteZDZ.Application.Services
{
    public  class ProductService : IProductService
    {
       private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
         }

        public async Task<ProductDto> AddProductAsync(CreateProductDto productDto)
        {
            if (productDto == null) throw new Exception("Error");
            var product = _mapper.Map<Product>(productDto);

            await _productRepository.AddAsync(product);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> DeleteProductAsync(Guid id)
        {
            var product = _productRepository.GetByIdAsync(id);

            await _productRepository.DeleteAsync(id);

            return null;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var products =  await _productRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async  Task<List<ProductDto>> SearchBySupplier(string nameSupplier)
        {
            var product = await _productRepository.SearchBySupplier(nameSupplier);

            return _mapper.Map<List<ProductDto>>(product);  
        }

        public async Task<ProductDto> UpdateProductAsync(Guid id, CreateProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (productDto == null)
            {
                throw new Exception("Não Encontrado");
            }
            _mapper.Map(productDto, product);

            await _productRepository.UpdateAsync(product);

            return _mapper.Map<ProductDto>(product);
        }
    }
}
