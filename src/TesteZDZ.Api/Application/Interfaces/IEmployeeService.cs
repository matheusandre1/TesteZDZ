using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;

namespace TesteZDZ.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid Id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto agendadto);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, CreateEmployeeDto dto);
        Task<EmployeeDto> DeleteEmployeeAsync(Guid id);

        Task<EmployeeDto> SearchEmployeeByName(string name);
    }
}
