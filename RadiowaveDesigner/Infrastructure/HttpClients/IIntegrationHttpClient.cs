namespace RadiowaveDesigner.Infrastructure.HttpClients;

internal interface IIntegrationHttpClient
{
    Task<TResponseBody> Get<TResponseBody>(
        Uri url,
        IReadOnlyDictionary<string, string> queryParams);
}