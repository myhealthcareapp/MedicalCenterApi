using Application.Services.Doctors.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator()
        {
            RuleFor(d => d.Name)
                .Length(3, 100)
                .WithMessage("Name must be atleast 3 charecter and maximum 100 - Ali")
;

            RuleFor(d => d.Description)
                .NotEmpty()
                .WithMessage("Description is required by Ali Zafar");


        }

    }
}
