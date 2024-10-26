using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Domain.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> SearchEmployeeByName(string name);
    }
}
