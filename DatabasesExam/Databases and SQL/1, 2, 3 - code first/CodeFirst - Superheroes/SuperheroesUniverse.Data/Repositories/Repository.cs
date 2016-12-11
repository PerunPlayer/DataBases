using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using SuperheroesUniverse.Data.Repository;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SuperheroesUniverse.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISuperheroDBContext context;

        public Repository(ISuperheroDBContext context)
        {
            this.context = context;
            this.DbSet = this.context.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return this.DbSet; }
        }

        public DbContextConfiguration Configuration
        {
            get { return this.context.Configuration; }
        }

        protected IDbSet<T> DbSet { get; private set; }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public void Add(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            (this.context.Set<T>() as DbSet<T>).AddRange(entities);
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
