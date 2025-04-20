using Microsoft.EntityFrameworkCore;
using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected RepositoryDbContext RepositoryDbContext;
        public BaseRepository(RepositoryDbContext repositoryContext)
        => RepositoryDbContext = repositoryContext;
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryDbContext.Set<T>().AsNoTracking() : RepositoryDbContext.Set<T>();
        public IQueryable<T> FindByCondition
            (Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
        RepositoryDbContext.Set<T>()
        .Where(expression)
        .AsNoTracking() :
        RepositoryDbContext.Set<T>()
        .Where(expression);
        public void Create(T entity) => RepositoryDbContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryDbContext.Set<T>().Update(entity); // for disconnected update "Another Context"
        public void Delete(T entity) => RepositoryDbContext.Set<T>().Remove(entity);
    }
}
