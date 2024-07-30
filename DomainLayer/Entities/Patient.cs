using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Gender { get; set; } = default!;

        public string HealthCardNumber { get; set; } = default!;

        public Address? Address { get; set; }
        public List<Medicine> Medicine { get; set; } = new();



    }
}
