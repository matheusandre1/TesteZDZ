using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Api.Application.Response
{
    public class RevenueDto
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
