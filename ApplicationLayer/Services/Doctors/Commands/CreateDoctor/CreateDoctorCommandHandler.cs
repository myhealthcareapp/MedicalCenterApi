using Domain.Entities;
using Domain.Repositories;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandHandler(ILogger<CreateDoctorCommandHandler> logger,
        IMapper mapper, IDoctorsRepository doctorsRepository) : IRequestHandler<CreateDoctorCommand, ErrorOr<int>>
    {
        public async Task<ErrorOr<int>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Creating a new Doctor {request}");
            var doctor = mapper.Map<Doctor>(request);

            var doctorId = await doctorsRepository.Create(doctor);
            return doctorId;
        }
    }
}
