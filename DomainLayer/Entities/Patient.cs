using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = default!;

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(50)]
        public int LastName { get; set; } = default!;

        [MaxLength(250)]
        public int Email { get; set; } = default!;

        [MaxLength(50)]
        public int Phone { get; set; } = default!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; } = default!;

        [MaxLength(20)]
        public string? MaritalStatus { get; set; } = default!;


        [Required]
        public Address? Address { get; set; }

        [MaxLength(50)]
        public string? OHIP { get; set; }

        [MaxLength(20)]
        public string? UCINumber { get; set; }

        //Picture IFH Paperwork
        //Picture Passport

        public DateTime DateRequested { get; set; }
        public DateTime DateApproved { get; set; }

        public bool IsActive { get; set; } = true;


        [MaxLength(50)]
        public string? EmergencyContactName { get; set; }

        [MaxLength(20)]
        public string? EmergencyContactPhoneNumber { get; set; }

        [MaxLength(100)]
        public string? EmergencyContactRelationship { get; set; }

        public Doctor? FamilyDoctor { get; set; }

        public bool isDoctorAssigned { get; set; } = false;

        [MaxLength(500)]
        public string? CurrentMedications { get; set; }

        [MaxLength(500)]
        public string? Allergies { get; set; }

        [MaxLength(500)]
        public string? MedicalHistory { get; set; }
        [MaxLength(250)]
        public string? Notes { get; set; }





    }
}
