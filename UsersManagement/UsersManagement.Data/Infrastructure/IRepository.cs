using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Data.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> Query();
        IEnumerable<T> Query(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
