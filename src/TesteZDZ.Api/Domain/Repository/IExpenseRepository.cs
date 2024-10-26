using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Domain.Repository
{
    public  interface IExpenseRepository : IRepository<Expense>
    {
        Task <List<Expense>> SearchExpenseByCategory (Category category);
        Task<List<Expense>> SearchExpenseByPaymentMethod (PaymentMethod paymentMethod);
    }
}
