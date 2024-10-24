using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Infrastructure.Mapping
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Despesas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.Description).IsRequired();
            builder.Property(x=> x.Category).IsRequired();
            builder.Property(x=> x.Value).IsRequired();
            builder.Property(x=> x.PaymentMethod).IsRequired();
        }
    }
}
