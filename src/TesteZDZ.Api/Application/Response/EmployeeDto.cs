using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Api.Application.Response
{
    
        public class EmployeeDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string CPF { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public decimal Salary { get; set; }
            public string Address { get; set; }
            public TypeOfContract TypeOfContract { get; set; }
        }
    
}
