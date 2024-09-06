using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProClinics.Models;

namespace ProClinics.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.CPF)
               .IsRequired(true)
               .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Crm)
               .IsRequired(true)
               .HasColumnType("VARCHAR(8)");

            builder.Property(x => x.CellPhoneNumber)
               .IsRequired(true)
               .HasColumnType("VARCHAR(1)");

            builder.HasOne(x => x.Speciality)
               .WithMany(s => s.Doctors)
               .HasForeignKey(d => d.SpecialityId)
               .OnDelete(DeleteBehavior.Restrict);
    
            builder.HasIndex(x => x.CPF)
                .IsUnique();

            builder.HasMany(d => d.Scheduling)
                .WithOne(s => s.Doctor)
                .HasForeignKey(d=>d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
