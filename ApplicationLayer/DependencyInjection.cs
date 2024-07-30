using Application.Common.Behaviors;
using Application.Interface.Services;
using Application.Services.Authentication;
using Application.Services.Authentication.Commands.Register;
using Application.Services.Doctors;
using ErrorOr;
using FluentValidation;
using FluentValidation.AspNetCore;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //  services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IMapper, ServiceMapper>();

            var applicationAssembly = typeof(DependencyInjection).Assembly;
            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

            return services;
        }
    }
}
