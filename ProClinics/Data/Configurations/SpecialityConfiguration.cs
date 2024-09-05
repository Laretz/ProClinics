using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProClinics.Models;

namespace ProClinics.Data.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("Speciality");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Description)
               .IsRequired(false)
               .HasColumnType("VARCHAR(150)");

            builder.HasMany(s => s.Doctors)
               .WithOne(d => d.Speciality)
               .OnDelete(DeleteBehavior.Restrict);

           

          
        }
    }
}
