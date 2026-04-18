using System;
using System.Linq;
using System.Linq.Expressions;
using CodeMan.Redis.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace CodeMan.Redis.Base.EntityFrameworkCore.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T :class
    {
        protected RedisDbContext RedisDbContext { get; set; }

        protected RepositoryBase(RedisDbContext repositoryContext)
        {
            RedisDbContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RedisDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RedisDbContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            RedisDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RedisDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RedisDbContext.Set<T>().Remove(entity);
        }
    }
}