using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PizzaMoreApp.Data.Interfaces
{
    public interface IRepository<T> where T :class
    {
        void Add (T entity);
        void Remove (T entity);
        IEnumerable<T> All();
        IEnumerable<T> All(Expression<Func<T,bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T Find(object id);
    }
}