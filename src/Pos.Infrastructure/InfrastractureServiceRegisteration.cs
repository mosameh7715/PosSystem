using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Infrastructure.Repositories;
using Pos.Application;

namespace Pos.Infrastructure;

public static class InfrastractureServiceRegisteration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication(); 

        services.AddDbContext<PosDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PosDbConnection"));
        });

        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IPosMachineRepository, PosMachineRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IInvoiceItemsRepository, InvoiceItemsRepository>();

        return services;
    }
}
