using Microsoft.EntityFrameworkCore;
using ParkingServiceStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServiceStores.Data.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly ApplicationDbContext _dbContext;
        public CarRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task AddAsync(Car car)
        {
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car car)
        {
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> FindAsync(Func<Car, bool> predicate)
        {
            return (await _dbContext.Cars.Include(r=>r.Owner).ToListAsync()).Where(predicate).ToList();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _dbContext.Cars.Include(r => r.Owner).ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _dbContext.Cars.Include(r=>r.Owner).Where(r=>r.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            _dbContext.Cars.Update(car);
            await _dbContext.SaveChangesAsync();
        }
    }
}
