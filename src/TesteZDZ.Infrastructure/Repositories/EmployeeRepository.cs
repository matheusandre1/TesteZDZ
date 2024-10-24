using Microsoft.EntityFrameworkCore;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Repository;
using TesteZDZ.Infrastructure.Context;
using TesteZDZ.Infrastructure.Database;

namespace TesteZDZ.Infrastructure.Repositories
{
    public  class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context) { }

        public async Task<Employee> SearchEmployeeByName(string name)
        {
            var filter = await this.Query.FirstOrDefaultAsync(x=> x.Name == name);

            return filter;
        }
    }
}
