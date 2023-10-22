using System.Net;
using RestSharp;

namespace RadiowaveDesigner.Infrastructure.Validators;

internal class IntegrationHttpResponseValidator : IIntegrationHttpResponseValidator
{
    public RestResponse Validate(RestResponse response)
    {
        if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.Conflict)
        {
            throw new HttpRequestException(
                $"{response.ErrorMessage}. Content: {response.Content}",
                response.ErrorException);
        }

        return response;
    }
}