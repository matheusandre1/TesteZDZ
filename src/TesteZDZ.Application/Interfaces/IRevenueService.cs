using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Interfaces
{
    public  interface IRevenueService
    {
        Task<RevenueDto> GetByIdAsync(Guid id);
        Task<IEnumerable<RevenueDto>> GetAllAsync();
        Task<RevenueDto> AddAsync(RevenueDto entity);
        Task<RevenueDto> UpdateAsync(Guid id,RevenueDto entity);
        Task<RevenueDto> DeleteAsync(Guid id);
        Task<List<RevenueDto>> SearchByPaymentMethod(PaymentMethod paymentMethod);
    }
}
