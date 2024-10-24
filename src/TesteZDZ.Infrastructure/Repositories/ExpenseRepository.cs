using Microsoft.EntityFrameworkCore;
using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;
using TesteZDZ.Domain.Repository;
using TesteZDZ.Infrastructure.Context;
using TesteZDZ.Infrastructure.Database;

namespace TesteZDZ.Infrastructure.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(DataContext context ) : base(context) { }
        public async Task<List<Expense>> SearchExpenseByCategory(Category category)
        {
            var filter = await Query.Where(x => x.Category == category).ToListAsync();
            return filter;
        }


        public async Task<List<Expense>> SearchExpenseByPaymentMethod(PaymentMethod paymentMethod)
        {
            var filter = await Query.Where(x => x.PaymentMethod == paymentMethod).ToListAsync();

            return filter;
        }
    }
}
