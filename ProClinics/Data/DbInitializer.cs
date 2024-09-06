using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using ProClinics.Models;

namespace ProClinics.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole
                    {
                        Id = "8305f33b-5412-47d0-b4ab-17cf6867f2e2",
                        Name = "Recepcionist",
                        NormalizedName = "RECEPCIONIST"
                    },
                    new IdentityRole
                    {
                        Id = "00043fbd-e5e1-49eb-8e36-837561d584f1",
                        Name = "Doctor",
                        NormalizedName = "DOCTOR"
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Receptionist>().HasData
                (
                new Receptionist
                {
                    Id = "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                    Name = "Pro Clinics",
                    Email = "proconsulta@hotmail.com.br",
                    EmailConfirmed = true,
                    UserName = "proconsulta@hotmail.com.br",
                    NormalizedEmail = "PROCONSULTA@HOTMAIL.COM.BR",
                    NormalizedUserName = "PROCONSULTA@HOTMAIL.COM.BR",
                    PasswordHash = hasher.HashPassword(null, "pa$$w0rd")
                }
                );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    RoleId = "8305f33b-5412-47d0-b4ab-17cf6867f2e2",
                    UserId = "95433ac4-2fe9-468f-b80d-b05ec3724d1d"
                }
            );

            _modelBuilder.Entity<Speciality>().HasData
                (
                    new Speciality { Id = 1, Name = "Cardiology", Description = "Heart-related conditions" },
                    new Speciality { Id = 2, Name = "Neurology", Description = "Nervous system disorders" },
                    new Speciality { Id = 3, Name = "Orthopedics", Description = "Bone and joint disorders" },
                    new Speciality { Id = 4, Name = "Pediatrics", Description = "Children's health" },
                    new Speciality { Id = 5, Name = "Gastroenterology", Description = "Digestive system disorders" },
                    new Speciality { Id = 6, Name = "Dermatology", Description = "Skin conditions" },
                    new Speciality { Id = 7, Name = "Endocrinology", Description = "Hormonal and metabolic disorders" },
                    new Speciality { Id = 8, Name = "Pulmonology", Description = "Lung and respiratory issues" },
                    new Speciality { Id = 9, Name = "Oncology", Description = "Cancer treatment and management" },
                    new Speciality { Id = 10, Name = "Ophthalmology", Description = "Eye and vision care" }
                );
        }
    }
}
