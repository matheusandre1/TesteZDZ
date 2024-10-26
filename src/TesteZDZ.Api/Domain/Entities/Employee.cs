using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Domain.Entities
{
    public  class Employee : BaseEntity
    {
        public Employee(string name, string lastName, string cPf, string email, string phoneNumber, decimal salary, string address, TypeOfContract typeOfContract)
        {
            Name = name;
            LastName = lastName;
            CPf = cPf;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Address = address;
            TypeOfContract = typeOfContract;
        }


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
