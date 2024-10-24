using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Interfaces
{
    public  interface IExpenseService
    {
        Task<ExpenseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ExpenseDto>> GetAllAsync();
        Task<ExpenseDto> AddAsync(ExpenseDto employeeDto);
        Task<ExpenseDto> UpdateAsync(Guid id,ExpenseDto employeeDto);
        Task<ExpenseDto> DeleteAsync(Guid id);
        Task<List<ExpenseDto>> SearchExpenseByCategory(Category category);
        Task<List<ExpenseDto>> SearchExpenseByPaymentMethod(PaymentMethod paymentMethod);
    }
}
