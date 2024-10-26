using AutoMapper;
using TesteZDZ.Api.Application.Response;
using TesteZDZ.Application.Dtos;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Application
{
    public  class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<Employee, EmployeeDto>();            

            CreateMap<CreateExpenseDto, Expense>();

            CreateMap<Expense, ExpenseDto>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<Product, ProductDto>();

            CreateMap<CreateRevenueDto, Revenue>();

            CreateMap<Revenue, RevenueDto>();
        }
    }
}
