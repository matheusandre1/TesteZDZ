using TesteZDZ.Domain.Base;

namespace TesteZDZ.Domain.Entities
{
    public  class Product : BaseEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Validity {  get; set; }
        public string Supplier {  get; set; }
    }
}
