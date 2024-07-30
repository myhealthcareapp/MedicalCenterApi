using Application.Services.Doctors.Dtos;
using Application.Services.Doctors.Queries.GetAllDoctors;
using Application.Services.Doctors.Queries.GetDoctorsbyId;
using Domain.Repositories;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Queries.GetDoctorsById
{
    internal class GetDoctorByIdQueryHandler(ILogger<GetDoctorByIdQueryHandler> logger,
        IMapper mapper, IDoctorsRepository doctorsRepository) : IRequestHandler<GetDoctorByIdQuery, DoctorDto?>
    {
        public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Doctor By Id: {0}", request.Id);
            var doctor = await doctorsRepository.GetDoctorById(request.Id);
            var doctorDTO = mapper.Map<DoctorDto>(doctor);
            return doctorDTO;
        }
    }
}
