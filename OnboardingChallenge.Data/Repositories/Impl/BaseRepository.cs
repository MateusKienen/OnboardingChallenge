using Microsoft.EntityFrameworkCore;
using OnboardingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Data.Repositories.Impl
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly OnboardingChallengeDbContext context;

        public BaseRepository(OnboardingChallengeDbContext context)
        {
            this.context = context;
            this.EntityDbSet = this.context.Set<TEntity>();
        }

        public DbSet<TEntity> EntityDbSet { get; set; }

        public async Task<TEntity> CreateAsync<T>(TEntity entity, CancellationToken cancellationToken)
        {
            this.EntityDbSet.Add(entity);
            await this.context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync<T>(TEntity entity, CancellationToken cancellationToken)
        {
            this.EntityDbSet.Remove(entity);
            await this.context.SaveChangesAsync(cancellationToken);
        }

        public Task<List<TEntity>> GetAsync<T>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var query = this.EntityDbSet.AsQueryable<TEntity>();
            query = query.Where(predicate);
            return query.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetAsync<T>(long id, CancellationToken cancellationToken)
        {
            return await this.GetQuery().Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return this.EntityDbSet.AsQueryable<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> UpdateAsync<T>(TEntity entity, CancellationToken cancellationToken)
        {
            this.EntityDbSet.Update(entity);
            await this.context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
