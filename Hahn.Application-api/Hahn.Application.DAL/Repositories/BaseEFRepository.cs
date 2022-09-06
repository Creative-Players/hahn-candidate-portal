using Hahn.Application.DAL.Data;
using Hahn.Application.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.DAL.Repositories
{
    public class BaseEFRepository<T> : IRepository<T> where T : class
    {
        private readonly HahnApplicationDbContext _db;

        public BaseEFRepository(HahnApplicationDbContext db)
        {
            _db = db;
        }

        public virtual async Task<T> AddItem(T tEntity)
        {
            try
            {
                await _db.Set<T>().AddAsync(tEntity);
                return (await _db.SaveChangesAsync()) > 0 ? tEntity : null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<T>> AddItems(IEnumerable<T> tEntities)
        {
            try
            {
                await _db.Set<T>().AddRangeAsync(tEntities);
                return (await _db.SaveChangesAsync()) > 0 ? tEntities : null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public virtual async Task<T> Find(int Id)
        {
            try
            {
                return await _db.Set<T>().FindAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool isTracked = true)
        {
            throw new NotImplementedException();
        }


        public virtual async Task<IEnumerable<T>> GetItems()
        {
            try
            {
                return await _db.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<IEnumerable<T>> GetItems(Func<T, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _db.Set<T>().Where(predicate).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> Remove(int id)
        {
            try
            {
                var item = await Find(id);
                if (item == null)
                    return false;
                _db.Set<T>().Remove(item);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> RemoveRange(IEnumerable<T> TEntities)
        {

            try
            {
                _db.Set<T>().RemoveRange(TEntities);
                return await _db.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateItem(int id, T updatedEntity)
        {
            try
            {
                var item = await Find(id);
                if (item == null)
                    throw new KeyNotFoundException($"Item with key {id} not found");
                _db.Entry<T>(updatedEntity).State = EntityState.Modified;
                var updated = await _db.SaveChangesAsync() == 1;
                return updated ? item : null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
