using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TimesheetPoc.Persistence
{
    public interface IRepository<T>
    {
        IList<T> FindAll();
        IList<T> FindBy(Expression<Func<T, bool>> predicate);
        
        T FindById(int id);
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
