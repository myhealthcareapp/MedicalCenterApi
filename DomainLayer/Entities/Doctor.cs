using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{ 
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        [Required]
        public Address? Address { get; set; }

        public string? Specializtions { get; set; }
        public string? Education { get; set; }

        [Required]
        public string LicenseNumber { get; set; } = default!;   

        [Required]
        public DateTime DateOfJoining { get; set; }
        public DateTime? EndDate { get; set; }

        [Range(0, int.MaxValue)]
        public int ConsultationFees { get; set; }

        [StringLength(250)]
        public string Notes { get; set; } = default!;

        [MaxLength(20)]
        public string? MaritalStatus { get; set; } = default!;

        [MaxLength(50)]
        public string? EmergencyContactName { get; set; }
        
        [MaxLength(20)]
        public string? EmergencyContactPhoneNumber { get; set; }

        
        [MaxLength(100)]
        public string? SocialInsuranceNumber { get; set; }

        [MaxLength(100)]
        public string? TaxIdentificationNumber { get; set; }


        public bool IsActive { get; set; } = true;
        public string Specialization { get; set; } = default!;

        [MaxLength(500)]
        public string? Biography { get; set; }

        //Certifications
        //Profile Picture
    }
}
