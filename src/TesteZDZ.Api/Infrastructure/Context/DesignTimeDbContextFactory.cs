using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TesteZDZ.Infrastructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().Build();

            var builder = new DbContextOptionsBuilder<DataContext>();

            var connectionString = config.GetConnectionString("DefaultConnection");

            builder.UseSqlite(connectionString);
            
            return new DataContext(builder.Options);
        }
    }
}
