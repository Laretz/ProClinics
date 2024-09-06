using ProClinics.Models;

namespace ProClinics.Repositories.Schedulings
{
    public interface ISchedulingRepository
    {
        Task<List<Scheduling>> GetAllAsync();
        Task AddAsync(Scheduling scheduling); 
        Task DeleteByIdAsync(int id);
        Task<Scheduling?> GetByIdAsync(int id);
    }
}
