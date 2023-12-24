using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using ReadEase.Application.Behaviors;
using FluentValidation;

namespace ReadEase.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices
    (this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IBookService, BookService>();
        services.AddMediatR(cfr => cfr.RegisterServicesFromAssemblies(
            typeof(ReadEase.Application.AssemblyReference).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(
             typeof(ReadEase.Application.AssemblyReference).Assembly);

        return services;
    }
}
