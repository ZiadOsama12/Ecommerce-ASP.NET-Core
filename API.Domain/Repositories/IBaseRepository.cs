﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IBaseRepository<T> 
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> DeleteByCondition(Expression<Func<T, bool>> expression); // trying to solve the N+1 Delete.
    }
}
