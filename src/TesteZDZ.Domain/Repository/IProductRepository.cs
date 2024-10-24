using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> SearchBySupplier(string nameSupplier);
    }
}
