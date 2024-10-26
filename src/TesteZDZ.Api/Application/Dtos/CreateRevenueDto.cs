using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Dtos
{
    public  class CreateRevenueDto 
    {
        public string CNPJ { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
