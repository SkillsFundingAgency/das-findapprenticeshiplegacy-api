using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.FAA.Legacy.Application.Mediatr.Behaviours;
using SFA.DAS.FAA.Legacy.Data.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace SFA.DAS.FAA.Legacy.Application.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationRegistrations(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions));
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.RegisterServices();
        }
    }
}
