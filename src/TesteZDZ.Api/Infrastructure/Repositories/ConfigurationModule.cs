using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TesteZDZ.Domain.Repository;
using TesteZDZ.Infrastructure.Context;
using TesteZDZ.Infrastructure.Database;

namespace TesteZDZ.Infrastructure.Repositories
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString) 
        {

            services.AddDbContext<DataContext>(options =>
            options.UseSqlite(connectionString));


            services.AddScoped(typeof(Repository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();

            return services;
        }
    }
}
