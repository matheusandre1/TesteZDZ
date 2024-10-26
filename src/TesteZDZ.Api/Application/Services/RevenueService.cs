using AutoMapper;
using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Domain.Entities;
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

        public async  Task<RevenueDto> AddRevenueAsync(CreateRevenueDto revenueDto)
        {
            if (revenueDto == null) throw new Exception("Error");
            var revenue = _mapper.Map<Revenue>(revenueDto);

            await _revenueRepository.AddAsync(revenue);

            return _mapper.Map<RevenueDto>(revenue);
        }

        public async Task<RevenueDto> DeleteRevenueAsync(Guid id)
        {
            var product = _revenueRepository.GetByIdAsync(id);

            await _revenueRepository.DeleteAsync(id);

            return null;
        }

        public async Task<IEnumerable<RevenueDto>> GetAllRevenueAsync()
        {
            var revenues = await _revenueRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RevenueDto>>(revenues);
        }

        public async Task<RevenueDto> GetByIdAsync(Guid id)
        {
            var revenue = await _revenueRepository.GetByIdAsync(id);

            return _mapper.Map<RevenueDto>(revenue);
        }

        public async Task<List<RevenueDto>> SearchByPaymentMethod(PaymentMethod paymentMethod)
        {
            
            var revenue = await _revenueRepository.SearchByPaymentMethod(paymentMethod);

            return _mapper.Map<List<RevenueDto>>(revenue);
        }

        public async Task<RevenueDto> UpdateRevenueAsync(Guid id, CreateRevenueDto revenueDto)
        {
            var revenue = await _revenueRepository.GetByIdAsync(id);

            if (revenueDto == null)
            {
                throw new Exception("Não Encontrado");
            }
            _mapper.Map(revenueDto, revenue);

            await _revenueRepository.UpdateAsync(revenue);

            return _mapper.Map<RevenueDto>(revenue);
        }
    }
}
