using Microsoft.EntityFrameworkCore;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Repository;
using TesteZDZ.Infrastructure.Context;
using TesteZDZ.Infrastructure.Database;

namespace TesteZDZ.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }
        public async Task<List<Product>> SearchBySupplier(string nameSupplier)
        {
            var filter = await Query.Where(x=> x.Supplier == nameSupplier).ToListAsync();

            return filter;
        }
    }
}
