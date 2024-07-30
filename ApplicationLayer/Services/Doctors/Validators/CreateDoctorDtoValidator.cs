using Application.Services.Doctors.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Validators
{
    public class CreateDoctorDtoValidator : AbstractValidator<CreateDoctorDto>
    {
        public CreateDoctorDtoValidator()
        {
            RuleFor(d =>  d.Name)
                .NotEmpty()
                .Length(3,100)
                .WithMessage("Namemust be atleast 3 charecter and maximum 100 - Ali")
;

            RuleFor(d => d.Description)
                .NotEmpty()
                .WithMessage("Description is required");


        }

    }
}
