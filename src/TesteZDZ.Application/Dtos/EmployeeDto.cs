using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Dtos
{
    public  class EmployeeDto : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public TypeOfContract TypeOfContract { get; set; }
    }
}
