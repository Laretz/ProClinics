﻿    using Microsoft.EntityFrameworkCore;
    using ProClinics.Data;
    using ProClinics.Models;

    namespace ProClinics.Repositories.Patients
    {
        public class PatientRepository : IPatientRepository
        {
            private readonly ApplicationDbContext _context;
            public PatientRepository(ApplicationDbContext context)
            {
                _context = context;;
            }
            public async Task AddAsync(Patient patient)
            {
                _context.Patients.Add(patient);    
                await _context.SaveChangesAsync();
            }

            public async Task DeleteByIdAsync(int id)
            {
                var patient = await GetByIdAsync(id);
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }

            public async Task<List<Patient>> GetAllAsync()
            {
                return await _context.Patients
                    .AsNoTracking()
                    .ToListAsync();
            }

            public async Task<Patient?> GetByIdAsync(int id)
            {
                return await _context.Patients.SingleOrDefaultAsync(x =>  x.Id == id);
            }

            public async Task UpdateAsync(Patient patient)
            {
                _context.Update(patient);
                await _context.SaveChangesAsync(true);
            }
        }
    }
