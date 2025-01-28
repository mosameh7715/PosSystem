using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pos.Application;

public static class ApplicationServiceRegisterations
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
