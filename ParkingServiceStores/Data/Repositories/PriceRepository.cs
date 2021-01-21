using Microsoft.EntityFrameworkCore;
using ParkingServiceStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServiceStores.Data.Repositories
{
    public class PriceRepository : IRepository<Price>
    {
        private readonly ApplicationDbContext _dbContext;
        public PriceRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task AddAsync(Price price)
        {
            await _dbContext.Prices.AddAsync(price);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Price price)
        {
            _dbContext.Prices.Remove(price);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Price>> FindAsync(Func<Price, bool> predicate)
        {
            return (await _dbContext.Prices.ToListAsync()).Where(predicate);

        }

        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            return await _dbContext.Prices.ToListAsync();
        }

        public async Task<Price> GetByIdAsync(int id)
        {
            return await _dbContext.Prices.FindAsync(id);
        }

        public async Task UpdateAsync(Price price)
        {
            _dbContext.Prices.Update(price);
            await _dbContext.SaveChangesAsync();
        }
    }
}
