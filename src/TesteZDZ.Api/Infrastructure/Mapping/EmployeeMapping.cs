using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteZDZ.Domain.Entities;

namespace TesteZDZ.Infrastructure.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.LastName);
            builder.Property(x => x.CPf);
            builder.Property(x => x.Email);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Salary);
            builder.Property(x => x.Address);
            builder.Property(x => x.TypeOfContract);

            

        }
    }
}
