using Application.Services.Doctors.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors
{
    public class DoctorService(IDoctorsRepository doctorsRepository,
        ILogger<DoctorService> logger,
        IMapper mapper
        ) : IDoctorService
    {
        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            logger.LogInformation("Getting All Doctors");
            var doctors = await doctorsRepository.GetAllAsync();
            var dtos = doctors.Adapt<List<DoctorDto>>();
            return dtos;
        }

        public async Task<DoctorDto?> GetDoctorsById(int id)
        {
            logger.LogInformation("Getting Doctor By Id: {0}", id);
            var doctor = await doctorsRepository.GetDoctorById(id);
            var doctorDTO = mapper.Map<DoctorDto>(doctor);
            return doctorDTO;
        }

        public async Task<int> Create(CreateDoctorDto dto)
        {
            logger.LogInformation($"Creating a new Doctor {dto}");
            var doctor = mapper.Map<Doctor>(dto);

            var doctorId = await doctorsRepository.Create(doctor);
            return doctorId;
        }
    }
}
