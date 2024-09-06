using ProClinics.Models;

namespace ProClinics.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
    }
}
