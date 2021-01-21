using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingServiceStores.Data.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<IEnumerable<T>> FindAsync(Func<T, Boolean> predicate);
    }
}
