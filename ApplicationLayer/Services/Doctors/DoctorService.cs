using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors
{
    public class DoctorService(IDoctorsRepository doctorsRepository, ILogger<DoctorService> logger) : IDoctorService
    {
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            logger.LogInformation("Getting All Doctors");
            var doctors = await doctorsRepository.GetAllAsync();
            return doctors;
        }
    }
}
