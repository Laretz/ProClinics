using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProClinics.Models;

namespace ProClinics.Data.Configurations
{
    public class SchedulingConfiguration : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.ToTable("Scheduling");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Notes)
                .IsRequired(false)
                .HasColumnType("VARCHAR(250)");

            builder.Property(x => x.PatientId)
                .IsRequired(true);

            builder.Property(x=> x.DoctorId)
                .IsRequired(true);
        }
    }
}
