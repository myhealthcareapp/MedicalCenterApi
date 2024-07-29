using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Dos.Doctors
{
    public class DoctorDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static DoctorDto FromEntity(Doctor? doctor)
        {
            if (doctor == null) 
                return null;
            return new DoctorDto { Name = doctor.Name, Description = doctor.Description };
        }
    }
}
