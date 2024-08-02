using Application.Services.Doctors.Commands.CreateDoctor;
using Domain.Common.Errors;
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

namespace Application.Services.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler(ILogger<DeleteDoctorCommandHandler> logger,
         IDoctorsRepository doctorsRepository) : IRequestHandler<DeleteDoctorCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting Doctor with id : {request.Id}");
            var doctor = await doctorsRepository.GetDoctorById(request.Id);

            if (doctor == null)
            {
                return Errors.Doctor.DoctorDoesNotExist;
            }
            await doctorsRepository.Delete(doctor);
            return true;
        }
    }
}
