using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EducationCenter.Infrastructure.Persistence;

namespace EducationCenter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("Default")
                 ?? "Host=localhost;Port=5432;Database=EducationCenter;Username=postgres;Password=postgres";

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("Default")));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        // services.AddScoped<IYourRepository, YourRepository>();
        return services;
    }
}
