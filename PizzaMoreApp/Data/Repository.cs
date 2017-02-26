using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PizzaMoreApp.Data.Interfaces;

namespace PizzaMoreApp.Data
{
    public class Repository<T> : IRepository<T> where T :class
    {
        protected DbSet<T> entitySet;

        
        public Repository(DbContext dbContext )
        {
            this.entitySet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            entitySet.Add(entity);
        }

        public void Remove(T entity)
        {
            this.entitySet.Remove(entity);
        }

        public IEnumerable<T> All()
        {
            return this.entitySet;
        }

        public IEnumerable<T> All(Expression<Func<T, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }


        public T First(Expression<Func<T, bool>> predicate)
        {
            return this.entitySet.FirstOrDefault(predicate);
        }

        public T Find(object id)
        {
            return this.entitySet.Find(id);
        }
    }
}
