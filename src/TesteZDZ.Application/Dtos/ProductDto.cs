﻿using TesteZDZ.Domain.Base;

namespace TesteZDZ.Application.Dtos
{
    public  class ProductDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Validity { get; set; }
        public string Supplier { get; set; }
    }
}
