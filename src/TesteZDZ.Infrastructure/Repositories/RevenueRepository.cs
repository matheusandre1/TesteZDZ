using Microsoft.EntityFrameworkCore;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;
using TesteZDZ.Domain.Repository;
using TesteZDZ.Infrastructure.Context;
using TesteZDZ.Infrastructure.Database;

namespace TesteZDZ.Infrastructure.Repositories
{
    public class RevenueRepository : Repository<Revenue>, IRevenueRepository
    {
        public RevenueRepository(DataContext context) : base(context) { }

        public async Task<List<Revenue>> SearchByPaymentMethod(PaymentMethod paymentMethod)
        {
            var filter = await Query.Where(x=> x.PaymentMethod == paymentMethod).ToListAsync();

            return filter;
        }
    }
}
