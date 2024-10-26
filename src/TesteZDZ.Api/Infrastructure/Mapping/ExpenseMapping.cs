using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Infrastructure.Mapping
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description);
            builder.Property(x => x.Category);
            builder.Property(x => x.Value);
            builder.Property(x => x.PaymentMethod);
        }
    }
}
