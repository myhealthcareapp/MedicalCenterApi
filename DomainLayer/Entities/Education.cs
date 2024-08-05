using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string InstitutionName { get; set; } = default!;

        [Required, StringLength(100)]
        public string Degree { get; set; } = default!;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; } = default!;

        // Navigation property to link doctors to education records
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
