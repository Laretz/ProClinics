using Microsoft.EntityFrameworkCore;
using ProClinics.Data;
using ProClinics.Models;

namespace ProClinics.Repositories.Specialitys
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Speciality>> GetAllAsync()
        {
            return await _context.Specialitys
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
