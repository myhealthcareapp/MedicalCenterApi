using Application.Services.Doctors.Commands.DeleteDoctor;
using Domain.Repositories;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler(ILogger<UpdateDoctorCommandHandler> logger,
        IMapper mapper, IDoctorsRepository doctorsRepository) : IRequestHandler<UpdateDoctorCommand, bool>
    {
        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating Doctor with id : {request.Id}");
            var doctor = await doctorsRepository.GetDoctorById(request.Id);

            if (doctor is null)
            {
                return false;
            }
            mapper.Map(request, doctor);
            await doctorsRepository.UpdateDoctor(doctor);
            return true;
        }
    }
}
