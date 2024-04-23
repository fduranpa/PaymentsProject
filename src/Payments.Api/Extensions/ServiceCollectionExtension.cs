using Payments.Application.Configurations;
using Payments.Application.Gateways;
using Payments.Application.Interactors;
using Payments.Application.Interactors.Abstractions;
using Payments.Infrastructure.Data.DAOs;
using Payments.Infrastructure.Data.Extensions;
using Payments.Infrastructure.Services.Services;

namespace Microsoft.Extensions.DependencyInjection;

internal static class ServiceCollectionExtension
{
    internal static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStrings = configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>()!;
        services.AddSingleton(connectionStrings);

        services.AddInjections(connectionStrings);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddInjections(this IServiceCollection services, ConnectionStrings connection)
    {
        //Interactors
        services.AddScoped<IGetAuthorizationInteractor, GetAuthorizationInteractor>();
        services.AddScoped<IGetApprovedAuthorizationsInteractor, GetApprovedAuthorizationsInteractor>();

        //External Services
        services.AddScoped<IPaymentProcessorService, PaymentProcessorService>();

        //DAOs
        services.AddScoped<IAuthorizationGateway, AuthorizationDAO>();

        //DataBase Connection
        services.AddDbContextAuthorization(connection.MySqlConnection);

        return services;
    }
}
