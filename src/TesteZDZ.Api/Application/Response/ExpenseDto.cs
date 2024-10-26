using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Api.Application.Response
{
    public class ExpenseDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
