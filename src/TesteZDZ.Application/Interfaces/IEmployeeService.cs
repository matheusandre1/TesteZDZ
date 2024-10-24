using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid Id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto agendadto);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, EmployeeDto dto);
        Task<EmployeeDto> DeleteEmployeeAsync(Guid id);

        Task<EmployeeDto> SearchEmployeeByName(string name);
    }
}
