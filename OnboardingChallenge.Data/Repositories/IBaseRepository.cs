using OnboardingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingChallenge.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> GetAsync<T>(long id, CancellationToken cancellationToken);

        Task<List<TEntity>> GetAsync<T>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<TEntity> CreateAsync<T>(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync<T>(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync<T>(TEntity entity, CancellationToken cancellationToken);     

        IQueryable<TEntity> GetQuery();        
    }
}
