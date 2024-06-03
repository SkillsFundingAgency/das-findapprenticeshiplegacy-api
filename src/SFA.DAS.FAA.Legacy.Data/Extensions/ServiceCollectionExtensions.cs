using Microsoft.Extensions.DependencyInjection;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using System.Diagnostics.CodeAnalysis;
using SFA.DAS.FAA.Legacy.Data.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IHealthStatusRepository, HealthStatusRepository>();
            services.AddTransient<IUserReadRepository, UserRepository>();
            services.AddTransient<IApprenticeshipsReadRepository, ApprenticeshipsRepository>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

            return services;
        }
    }
}
