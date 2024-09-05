namespace ProClinics.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CellPhoneNumber { get; set; } = null!;
        public DateTime BithDate { get; set; }
        public ICollection<Scheduling> Scheduling { get; set; } = new List<Scheduling>();

    }
}
