using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Interfaces
{
    public  interface IRevenueService
    {
        Task<RevenueDto> GetByIdAsync(Guid id);
        Task<IEnumerable<RevenueDto>> GetAllRevenueAsync();
        Task<RevenueDto> AddRevenueAsync(CreateRevenueDto revenueDto);
        Task<RevenueDto> UpdateRevenueAsync(Guid id, CreateRevenueDto revenueDto);
        Task<RevenueDto> DeleteRevenueAsync(Guid id);
        Task<List<RevenueDto>> SearchByPaymentMethod(PaymentMethod paymentMethod);
    }
}
