using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Domain.Entities
{
    public  class Expense : BaseEntity
    {      
        public string Description  { get; set; } 
        public Category Category { get; set; }
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
