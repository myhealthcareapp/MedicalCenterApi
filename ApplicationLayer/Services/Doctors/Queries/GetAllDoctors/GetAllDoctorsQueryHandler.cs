using Application.Services.Doctors.Commands.CreateDoctor;
using Application.Services.Doctors.Dtos;
using Domain.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler(ILogger<GetAllDoctorsQueryHandler> logger,
        IMapper mapper, IDoctorsRepository doctorsRepository) : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorDto>>
    {
        public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Doctors");
            var doctors = await doctorsRepository.GetAllAsync();
            var dtos = doctors.Adapt<List<DoctorDto>>();
            return dtos;
        }
    }
}
 