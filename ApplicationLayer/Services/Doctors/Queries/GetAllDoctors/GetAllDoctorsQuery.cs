using Application.Services.Doctors.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQuery : IRequest<IEnumerable<DoctorDto>>
    {
    }
}
