using System.Net.Mime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using RadiowaveDesigner.Infrastructure.HttpClients;
using RadiowaveDesigner.Infrastructure.HttpClients.YandexPlacesApi;
using RadiowaveDesigner.Infrastructure.Settings;
using RadiowaveDesigner.Infrastructure.Validators;
using RestSharp;

namespace RadiowaveDesigner.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddSingleton<IRestClient>(_ =>
            new RestClient()
                .AddDefaultHeader(HeaderNames.Accept, MediaTypeNames.Application.Json));

        services.AddTransient<IIntegrationHttpResponseValidator, IntegrationHttpResponseValidator>();
        services.AddTransient<IIntegrationHttpClient, IntegrationHttpClient>();
        services.AddTransient<IYandexPlacesHttpClient, YandexPlacesHttpClient>();
        services.RegisterSettings<PlacesApiSettings>();
    }

    public static void RegisterSettings<T>(this IServiceCollection services) where T : class
    {
        services.AddOptions<T>().Configure((Action<T, IConfiguration>)
            ((settings, configuration) => configuration.GetSection(typeof (T).Name).Bind(settings)));
    }
}