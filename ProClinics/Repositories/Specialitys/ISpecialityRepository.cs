using ProClinics.Models;

namespace ProClinics.Repositories.Specialitys
{
    public interface ISpecialityRepository
    {
        Task<List<Speciality>> GetAllAsync();
    }
}
