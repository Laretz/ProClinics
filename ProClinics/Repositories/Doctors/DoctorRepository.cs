using Microsoft.EntityFrameworkCore;
using ProClinics.Data;
using ProClinics.Models;

namespace ProClinics.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }   
        public async Task AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await GetByIdAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.Include(x => x.Speciality)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
