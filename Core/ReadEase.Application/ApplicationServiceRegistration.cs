using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ReadEase.Application.Services;
using System.Reflection;

namespace ReadEase.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices
    (this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IBookService, BookService>();
        services.AddMediatR(cfr => cfr.RegisterServicesFromAssemblies(
            typeof(ReadEase.Application.AssemblyReference).Assembly));
        return services;
    }
}
