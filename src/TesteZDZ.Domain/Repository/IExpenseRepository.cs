using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Domain.Repository
{
    public  interface IExpenseRepository : IRepository<Expense>
    {
        Task<Expense> SearchExpenseByCategory (Category category);
        Task<Expense> SearchExpenseByPaymentMethod (PaymentMethod paymentMethod);
    }
}
