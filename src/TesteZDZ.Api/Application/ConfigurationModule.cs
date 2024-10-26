using TesteZDZ.Application.Interfaces;
using TesteZDZ.Application.Services;

namespace TesteZDZ.Application
{
    public  static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRevenueService, RevenueService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;

        }
    }
}
