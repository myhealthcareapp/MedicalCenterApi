using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<ErrorOr<int>>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Specialities { get; set; } = default!;
    }
}
