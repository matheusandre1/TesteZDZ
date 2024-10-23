using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;
using TesteZDZ.Domain.ValueObject;

namespace TesteZDZ.Domain.Entities
{
    public  class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public CPF CPf { get; set; }
        public Email Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public TypeOfContract TypeOfContract { get; set; }
    }
}
