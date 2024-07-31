using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class DoctorsRepository(MedicalCenterDBContext dbContext) : IDoctorsRepository
    {
        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            var doctors = await dbContext.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            var doctor = await dbContext.Doctors.FindAsync(id);
            return doctor;
        }

        public async Task<int> Create(Doctor doctor)
        {
            dbContext.Doctors.Add(doctor);
            await dbContext.SaveChangesAsync();
            return doctor.Id;   
        }

        public async Task<bool> Delete(Doctor doctor)
        {
            dbContext.Remove(doctor);
            await dbContext.SaveChangesAsync(true);
            return true;
        }
    }
}
