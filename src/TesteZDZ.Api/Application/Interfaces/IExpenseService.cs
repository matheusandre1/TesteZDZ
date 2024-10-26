using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Interfaces
{
    public  interface IExpenseService
    {
        Task<ExpenseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ExpenseDto>> GetAllExpenseAsync();
        Task<ExpenseDto> CreateExpenseAsync(CreateExpenseDto expenseDto);
        Task<ExpenseDto> UpdateExpenseAsync(Guid id,CreateExpenseDto expenseDto);
        Task<ExpenseDto> DeleteExpenseAsync(Guid id);
        Task<List<ExpenseDto>> SearchExpenseByCategory(Category category);
        Task<List<ExpenseDto>> SearchExpenseByPaymentMethod(PaymentMethod paymentMethod);
    }
}
