using AutoMapper;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Application.Interfaces;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Repository;

namespace TesteZDZ.Application.Services
{
    public  class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeerepository = employeeRepository;
            _mapper = mapper;

        }
        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            if(employeeDto == null)
            {
                throw new Exception();
            }

            var employee = _mapper.Map<Employee>(employeeDto);

            await _employeerepository.AddAsync(employee);

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _employeerepository.GetByIdAsync(id);


            await _employeerepository.DeleteAsync(id);

            return null;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees =  await _employeerepository.GetAllAsync();

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeerepository.GetByIdAsync(id);

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Guid id, EmployeeDto employeedto)
        {
            var employee = await _employeerepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new Exception("Não Encontrado");
            }

            _mapper.Map(employeedto, employee);

            await _employeerepository.UpdateAsync(employee);

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> SearchEmployeeByName(string name)
        {
            var employee = await _employeerepository.SearchEmployeeByName(name);

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
