﻿using System.ComponentModel.DataAnnotations;

namespace MedicalCenterApi.Model
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
