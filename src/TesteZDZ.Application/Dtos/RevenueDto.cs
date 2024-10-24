using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Application.Dtos
{
    public  class RevenueDto : BaseEntity
    {
        public string CNPJ { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
