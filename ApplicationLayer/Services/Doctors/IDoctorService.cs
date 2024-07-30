using Application.Services.Doctors.Dtos;
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
        Task<IEnumerable<DoctorDto>> GetAllDoctors();
        Task<DoctorDto?> GetDoctorsById(int id);
        Task<int> Create(CreateDoctorDto dto);

        
    }
}
