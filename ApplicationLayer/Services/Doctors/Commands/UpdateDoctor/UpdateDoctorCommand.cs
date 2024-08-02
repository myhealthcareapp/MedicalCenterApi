using Application.Services.Doctors.Dtos;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<ErrorOr<bool>>
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name has to be more than 3 and less than 100 characters")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Descripion is required")]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; } = default!;

    }
}
