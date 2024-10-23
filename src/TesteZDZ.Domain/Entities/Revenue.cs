using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Domain.Entities
{
    public class Revenue : BaseEntity
    {
        public string CNPJ { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
