using EducationCenter.Service.Auth;
using EducationCenter.Service.Services;
using MediatR;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EducationCenter.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        var jwtSection = configuration.GetSection("Jwt");
        services.Configure<JwtOptions>(options =>
        {
            options.Issuer = jwtSection["Issuer"] ?? string.Empty;
            options.Audience = jwtSection["Audience"] ?? string.Empty;
            options.Key = jwtSection["Key"] ?? string.Empty;
            options.AccessTokenMinutes = int.TryParse(jwtSection["AccessTokenMinutes"], out var minutes)
                ? minutes
                : 0;
        });
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();

        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
