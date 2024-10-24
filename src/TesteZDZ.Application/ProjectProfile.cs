using AutoMapper;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Application
{
    public  class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeDto, Employee>();

            CreateMap<Expense, ExpenseDto>();

            CreateMap<ExpenseDto, Expense>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();

            CreateMap<Revenue, RevenueDto>();

            CreateMap<RevenueDto, Revenue>();
        }
    }
}
