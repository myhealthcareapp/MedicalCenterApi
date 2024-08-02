using Application.Services.Doctors.Dtos;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Queries.GetDoctorsbyId
{
    public class GetDoctorByIdQuery(int id) : IRequest<ErrorOr<DoctorDto>>
    {
        public int Id { get; set; } = id;
    }
}
