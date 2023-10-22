using RestSharp;

namespace RadiowaveDesigner.Infrastructure.Validators;

internal interface IIntegrationHttpResponseValidator
{
    RestResponse Validate(RestResponse response);
}