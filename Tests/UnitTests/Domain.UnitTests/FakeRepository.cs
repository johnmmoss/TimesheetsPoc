using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimesheetPoc.Persistence;

namespace TimesheetsPoc.Domain.UnitTests
{
    public class FakeRepository<T> : IRepository<T> where T : class
    {
        protected readonly HashSet<T> _set;

        public int Count
        {
            get { return _set.Count(); }
        }

        public FakeRepository()
        {
            _set = new HashSet<T>();
        }

        public IList<T> FindAll()
        {
            return _set.ToList();
        }

        public IList<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual T FindById(int id)
        {
            // Implement in overload
            return null;
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            // Implement in overload
        }
    }
}