using HomeworkApp.Dal.Infrastructure;
using HomeworkApp.Dal.Settings;

namespace HomeworkApp.Dal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDalInfrastructure(
        this IServiceCollection services,
        IConfigurationRoot config)
    {
        services.Configure<DalOptions>(config.GetSection(nameof(DalOptions)));

        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        Postgres.AddMigrations(services);

        return services;
    }
}
