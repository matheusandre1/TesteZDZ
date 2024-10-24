using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Infrastructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Validity).IsRequired();
            builder.Property(x => x.Supplier).IsRequired();
        }
    }
}
