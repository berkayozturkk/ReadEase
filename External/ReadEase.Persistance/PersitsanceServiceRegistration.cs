using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadEase.Persistance.Context;
using ReadEase.Persistance.Mapping;
using System.Reflection;

namespace ReadEase.Persistance;

public static class PersitsanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices
    (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ReadEaseDbConnStr")));

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
