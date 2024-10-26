using TesteZDZ.Domain.Base;

namespace TesteZDZ.Application.Dtos
{
    public  class CreateProductDto 
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Validity { get; set; }
        public string Supplier { get; set; } = string.Empty;
    }
}
