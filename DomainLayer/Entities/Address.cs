using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    {
        [Required, MaxLength(100)]
        public string StreetAddress { get; set; } = default!;

        [MaxLength(50)]
        public string? AddressLine2 { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; } = default!;

        [Required, MaxLength(50)]
        public string? State { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; } = default!;

    }
}
