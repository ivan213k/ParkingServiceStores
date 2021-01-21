using Microsoft.EntityFrameworkCore;
using ParkingServiceStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServiceStores.Data.Repositories
{
    public class DebtRepository : IRepository<Debt>
    {
        private readonly ApplicationDbContext _dbContext;
        public DebtRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task AddAsync(Debt debt)
        {
            await _dbContext.Debts.AddAsync(debt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Debt debt)
        {
            _dbContext.Debts.Remove(debt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Debt>> FindAsync(Func<Debt, bool> predicate)
        {
            return (await _dbContext.Debts.Include(r=>r.Car).ToListAsync()).Where(predicate);
        }

        public async Task<IEnumerable<Debt>> GetAllAsync()
        {
            return await _dbContext.Debts.Include(r => r.Car).ToListAsync();
        }

        public async Task<Debt> GetByIdAsync(int id)
        {
            return await _dbContext.Debts.Include(r => r.Car).Where(r=>r.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Debt debt)
        {
            _dbContext.Debts.Update(debt);
            await _dbContext.SaveChangesAsync();
        }
    }
}
