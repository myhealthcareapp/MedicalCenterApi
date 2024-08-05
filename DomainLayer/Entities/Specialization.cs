using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = default!;

        [Required, StringLength(200)]
        public string Description { get; set; } = default!;
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
