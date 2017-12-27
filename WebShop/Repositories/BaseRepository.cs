using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebShop.Interfaces;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly WebShopContext context;

        public BaseRepository(WebShopContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<long> Delete(long id)
        {
            T entityToDelete = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entityToDelete);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<T> Get(long id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}