namespace TesteZDZ.Api.Application.Response
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Validity { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public DateTime DateRegister { get; set; }
    }
}
