using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> SearchBySupplier(string nameSupplier);
    }
}
