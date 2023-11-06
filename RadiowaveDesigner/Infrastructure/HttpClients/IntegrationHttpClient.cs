using System.Text.Json;
using RadiowaveDesigner.Infrastructure.Validators;
using RestSharp;

namespace RadiowaveDesigner.Infrastructure.HttpClients;

internal class IntegrationHttpClient : IIntegrationHttpClient
{
    private readonly IRestClient _client;
    private readonly IIntegrationHttpResponseValidator _integrationHttpResponseValidator;

    public IntegrationHttpClient(
        IRestClient client,
        IIntegrationHttpResponseValidator integrationHttpResponseValidator)
    {
        _client = client;
        _integrationHttpResponseValidator = integrationHttpResponseValidator;
    }
    
    public async Task<TResponseBody> Get<TResponseBody>(
        Uri url,
        IReadOnlyDictionary<string, string> queryParams)
    {
        var request = new RestRequest(url);
        AddQueryParameters(request, queryParams);

        var response = await ExecuteRequest(request);
        return JsonSerializer.Deserialize<TResponseBody>(response.Content!);
    }
    private static void AddQueryParameters(RestRequest request, IReadOnlyDictionary<string, string> queryParams)
    {
        foreach (var queryParam in queryParams)
        {
            request.AddQueryParameter(queryParam.Key, queryParam.Value, false);
        }
    }
    
    private async Task<RestResponse> ExecuteRequest(RestRequest request)
    {
        var response = await _client.ExecuteAsync(request);
        return _integrationHttpResponseValidator.Validate(response);
    }
}