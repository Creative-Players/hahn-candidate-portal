using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Interfaces
{

    public interface IRepository<T> where T : class
    {
        Task<T> Find(int Id);
        Task<IEnumerable<T>> GetItems();
        Task<IEnumerable<T>> GetItems(Func<T, bool> predicate);
        Task<T> AddItem(T tEntity);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool isTracked = true);
        Task<IEnumerable<T>> AddItems(IEnumerable<T> tEntities);
        Task<T> UpdateItem(int id, T updatedEntity);
        Task<bool> Remove(int id);

        Task<bool> RemoveRange(IEnumerable<T> TEntities);
    }
}
