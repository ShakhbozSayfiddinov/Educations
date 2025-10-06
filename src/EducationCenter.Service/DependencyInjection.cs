using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace EducationCenter.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
