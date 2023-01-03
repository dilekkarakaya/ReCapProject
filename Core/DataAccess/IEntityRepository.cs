using System;
using Core.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetById(Expression<Func<T, bool>> filter );
        //T GetCarBy(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);

    }
}
