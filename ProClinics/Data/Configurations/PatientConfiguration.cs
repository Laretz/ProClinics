using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProClinics.Models;

namespace ProClinics.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.CPF)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.Property(x => x.Email)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.CellPhoneNumber)
                .IsRequired(true)
                .HasColumnType("NVARCHAR(11)");

            builder.HasIndex(x => x.CPF)
                .IsUnique();

            builder.HasMany( p => p.Scheduling)
                .WithOne( s => s.Patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
