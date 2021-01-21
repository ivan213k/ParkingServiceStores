using Microsoft.EntityFrameworkCore;
using ParkingServiceStores.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServiceStores.Data.Repositories
{
    public class JournalRepository : IRepository<JournalRecord>
    {
        private readonly ApplicationDbContext _dbContext;

        public JournalRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(JournalRecord record)
        {
            await _dbContext.Journal.AddAsync(record);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(JournalRecord record)
        {
            _dbContext.Journal.Remove(record);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<JournalRecord>> FindAsync(Func<JournalRecord, bool> predicate)
        {
            return (await _dbContext.Journal.Include(r => r.Car).ToListAsync()).Where(predicate);
        }

        public async Task<IEnumerable<JournalRecord>> GetAllAsync()
        {
            return await _dbContext.Journal.Include(r => r.Car).ToListAsync();
        }

        public async Task<JournalRecord> GetByIdAsync(int id)
        {
            return await _dbContext.Journal.Include(r => r.Car).Where(r=>r.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(JournalRecord record)
        {
            _dbContext.Journal.Update(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}
