using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Dtos
{
    public  class ExpenseDto : BaseEntity
    {
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
