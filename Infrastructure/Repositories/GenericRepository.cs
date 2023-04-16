using Application.Security.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> dbSet;
        private readonly RestaurantDbContext dbContext;
        public GenericRepository(RestaurantDbContext dbContext)
        {

            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

      
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await dbSet.FindAsync(new object[] { id } , cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await dbSet.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            TEntity entity = await GetByIdAsync(id, cancellationToken);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
