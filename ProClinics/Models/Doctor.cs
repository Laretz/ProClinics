namespace ProClinics.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string Crm { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CellPhoneNumber { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public int SpecialtyId { get; set; }
        public Speciality Speciality { get; set; } = null!;
        public ICollection<Scheduling> Scheduling { get; set; } = new List<Scheduling>();


    }
}
