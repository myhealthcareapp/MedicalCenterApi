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
            var applicationAssembly = Assembly.GetExecutingAssembly();

            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
           
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            


            services.AddScoped<IMapper, ServiceMapper>();

            

            return services;
        }
    }
}
