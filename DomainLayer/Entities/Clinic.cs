using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clinic
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = default!;

        [Required, StringLength(250)]
        public string? Email { get; set; }

        [Required, StringLength(100)]
        public string? Description { get; set; }

        [Required, StringLength(500)]
        public string? WebSite { get; set; }
        public Address Address { get; set; } = default!;

        public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
        public IList<Patient> Patients { get; set; } = new List<Patient>();

    }
}
