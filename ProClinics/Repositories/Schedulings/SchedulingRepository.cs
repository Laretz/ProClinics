using Microsoft.EntityFrameworkCore;
using ProClinics.Data;
using ProClinics.Models;

namespace ProClinics.Repositories.Schedulings
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly ApplicationDbContext _context;

        public SchedulingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Scheduling scheduling)
        {
            _context.Schedulings.Add(scheduling);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var scheduling = await GetByIdAsync(id);
            _context.Schedulings.Remove(scheduling);
            await _context.SaveChangesAsync();
        }

        public async Task<Scheduling?> GetByIdAsync(int id)
        {
           return await _context
                .Schedulings
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Scheduling>> GetAllAsync()
        {
            return await _context
               .Schedulings
               .Include(x => x.Doctor)
               .Include(x => x.Patient)
               .AsNoTracking()
               .ToListAsync();
        }
    }
}
