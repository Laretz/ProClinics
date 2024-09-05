namespace ProClinics.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public string? Notes {  get; set; }
        public int DoctorId {  get; set; }
        public int PatentId {  get; set; }
        public TimeSpan AppointmentTime {  get; set; }
        public DateTime AppointmentDate { get; set; }

        public Doctor Doctor { get; set; } = null!;
        public Patient Patient { get; set; } = null!; 


    }
}
