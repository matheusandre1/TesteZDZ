using Microsoft.EntityFrameworkCore;
using TesteZDZ.Domain.Base;
using TesteZDZ.Infrastructure.Context;

namespace TesteZDZ.Infrastructure.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query {  get; set; }
        protected DbContext Context { get; set; }

        public Repository(DataContext context)
        {
            Context = context;
            Query = Context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await Query.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await Query.FindAsync(id);
            Query.Remove(entity);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var consult = await this.Query.ToListAsync();

                return consult;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            
            return await this.Query.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            Query.Update(entity);

            await Context.SaveChangesAsync();
        }
    }
}
