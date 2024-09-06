using ProClinics.Models;

namespace ProClinics.Repositories.Patients
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteByIdAsync(int id);
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);

    }
}
