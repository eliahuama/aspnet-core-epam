using System.Linq;
using Microsoft.EntityFrameworkCore;
using Northwind.Entities;

namespace Northwind.Context {
    public interface IRepository<T> where T : class {
        void Add (T item);
        void Remove (T item);
        void Update(T iterm);
        IQueryable<T> Query ();
    }
}