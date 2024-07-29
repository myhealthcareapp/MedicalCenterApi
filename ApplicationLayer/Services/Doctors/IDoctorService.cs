using Application.Services.Doctors.Dos.Doctors;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors
{
    public interface IDoctorService
    {
        public Task<IEnumerable<DoctorDto>> GetAllDoctors();
        public Task<DoctorDto?> GetDoctorsById(int id);
    }
}
