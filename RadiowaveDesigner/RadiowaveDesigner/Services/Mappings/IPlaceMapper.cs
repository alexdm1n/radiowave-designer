using RadiowaveDesigner.Infrastructure.Models.Responses;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Mappings;

internal interface IPlaceMapper
{
    Places Map(PlacesResponse response);
}