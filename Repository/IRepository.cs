using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace mydapper.Repository
{
    public interface IRepository<T> where T: class
    {
         Task<int> Add(T item);
         Task<int> Remove(object ID, string customIdColumn = "ID");
         Task RemoveAll();
         Task<int> Update(T item, string customIdColumn = "ID");
         Task<T> FindById(object id, string columns="*", string customIdColumn = "ID");
         Task<IEnumerable<T>> FindAll(string columns="*");
         Task<IEnumerable<T>> Find(string condition, object param, string columns="*");
    }
}