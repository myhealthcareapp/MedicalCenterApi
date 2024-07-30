using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Dtos
{
    public class CreateDoctorDto
    {
        [StringLength(100, MinimumLength =3)]
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Specialities { get; set; } = default!;

    }
}
