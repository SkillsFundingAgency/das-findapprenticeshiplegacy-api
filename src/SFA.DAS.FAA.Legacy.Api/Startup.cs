using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SFA.DAS.Api.Common.AppStart;
using SFA.DAS.Api.Common.Configuration;
using SFA.DAS.Api.Common.Infrastructure;
using SFA.DAS.Configuration.AzureTableStorage;
using SFA.DAS.FAA.Legacy.Application.Extensions;
using SFA.DAS.FAA.Legacy.Domain.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SFA.DAS.FAA.Legacy.Api.AppStart;
using SFA.DAS.FAA.Legacy.Api.HealthCheck;

namespace SFA.DAS.FAA.Legacy.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly string _environmentName;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _environmentName = configuration["EnvironmentName"];
            var config = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddAzureTableStorage(options =>
                {
                    options.ConfigurationKeys = configuration["ConfigNames"].Split(",");
                    options.StorageConnectionString = configuration["ConfigurationStorageConnectionString"];
                    options.EnvironmentName = _environmentName;
                    options.PreFixConfigurationKeys = false;
                });
#if DEBUG
            config.AddJsonFile("appsettings.Development.json", true);
#endif

            Configuration = config.Build();
        }

        public IConfiguration Configuration { get; }

        private bool IsEnvironmentLocalOrDev =>
            _environmentName.Equals("LOCAL", StringComparison.CurrentCultureIgnoreCase)
            || _environmentName.Equals("DEV", StringComparison.CurrentCultureIgnoreCase);

        public void ConfigureServices(IServiceCollection services)
        {
            if (!IsEnvironmentLocalOrDev)
            {
                var azureAdConfiguration = Configuration
                    .GetSection("AzureAd")
                    .Get<AzureActiveDirectoryConfiguration>();

                var policies = new Dictionary<string, string>
                {
                    {PolicyNames.Default, RoleNames.Apim}
                };

                services.AddAuthentication(azureAdConfiguration, policies);
            }

            services.AddHealthChecks()
                .AddCheck<MongoHealthCheck>("Mongo Connection Health Check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "ready" });

            services.AddApplicationInsightsTelemetry();

            services.AddApiVersioning(opt =>
            {
                opt.ApiVersionReader = new HeaderApiVersionReader("X-Version");
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services
                .AddControllers(options =>
                {
                    if (!IsEnvironmentLocalOrDev)
                        options.Conventions.Add(new AuthorizeControllerModelConvention(new List<string>()));
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "FAA Legacy API Connector"
                        });

                    options.OperationFilter<SwaggerVersionHeaderFilter>();
                });

            services.Configure<MongoConfiguration>(Configuration.GetSection("MongoConfiguration"));
            services.AddSingleton<IMongoConfiguration>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoConfiguration>>().Value);

            services.AddApplicationRegistrations();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SFA.DAS.FAA.Legacy.Api v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = HealthCheckResponseWriter.WriteJsonResponse
            });

            app.UseHealthChecks("/ping", new HealthCheckOptions
            {
                Predicate = (_) => false,
                ResponseWriter = (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    return context.Response.WriteAsync("");
                }
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            if (!IsEnvironmentLocalOrDev)
                app.UseHealthChecks("/ping",
                    new HealthCheckOptions
                    {
                        Predicate = _ => false,
                        ResponseWriter = (context, report) =>
                        {
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsync("pong");
                        }
                    });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
