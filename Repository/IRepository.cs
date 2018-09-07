using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace mydapper.Repository
{
    public interface IRepository<T> where T: class
    {
         Task<int> Add(T item);
         Task<int> Remove(int ID);
         Task RemoveAll();
         Task<int> Update(T item);
         Task<T> FindById(int id, string columns="*");
         Task<IEnumerable<T>> FindAll(string columns="*");
         Task<IEnumerable<T>> Find(string condition, object param, string columns="*");
    }
}