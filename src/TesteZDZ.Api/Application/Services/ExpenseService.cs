using AutoMapper;
using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;
using TesteZDZ.Domain.Repository;

namespace TesteZDZ.Application.Services
{
    public  class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;

        }

        public async Task<ExpenseDto> CreateExpenseAsync(CreateExpenseDto expenseDto)
        {
            if (expenseDto == null) throw new ArgumentNullException(nameof(expenseDto));

            var expense = _mapper.Map<Expense>(expenseDto);

            await _expenseRepository.AddAsync(expense);

            return _mapper.Map<ExpenseDto>(expense);
        }

        public async Task<ExpenseDto> DeleteExpenseAsync(Guid id)
        {
            var expense = _expenseRepository.GetByIdAsync(id);

            await _expenseRepository.DeleteAsync(id);

            return null;
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllExpenseAsync()
        {
            var expense = await _expenseRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ExpenseDto>>(expense);
        }

        public async Task<ExpenseDto> GetByIdAsync(Guid id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);

            return _mapper.Map<ExpenseDto>(expense);
        }

        public async Task<List<ExpenseDto>> SearchExpenseByCategory(Category category)
        {
            var expense = await _expenseRepository.SearchExpenseByCategory(category);

            if(expense == null)
            {
                throw new Exception();
            }

            return _mapper.Map<List<ExpenseDto>>(expense);
        }

        public async Task<List<ExpenseDto>> SearchExpenseByPaymentMethod(PaymentMethod paymentMethod)
        {
            var expense = await _expenseRepository.SearchExpenseByPaymentMethod(paymentMethod);


            return _mapper.Map<List<ExpenseDto>>(expense);
        }

        public async Task<ExpenseDto> UpdateExpenseAsync(Guid id, CreateExpenseDto expenseDto)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);

            if (expenseDto == null)
            {
                throw new Exception("Não Encontrado");
            }
            _mapper.Map(expenseDto, expense);

            await _expenseRepository.UpdateAsync(expense);

            return _mapper.Map<ExpenseDto>(expense);
        }

    }
}
