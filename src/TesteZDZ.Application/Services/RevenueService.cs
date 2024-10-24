using AutoMapper;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Domain.Enums;
using TesteZDZ.Domain.Repository;

namespace TesteZDZ.Application.Services
{
    public  class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly IMapper _mapper;

        public RevenueService(IRevenueRepository revenueRepository, IMapper mapper)
        {
            _revenueRepository = revenueRepository;
            _mapper = mapper;
        }

        public Task<RevenueDto> AddAsync(RevenueDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<RevenueDto> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RevenueDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RevenueDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RevenueDto>> SearchByPaymentMethod(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Task<RevenueDto> UpdateAsync(Guid id, RevenueDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
