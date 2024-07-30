using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Dtos
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specialities { get; set; }

    }
}
