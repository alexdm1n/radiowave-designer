using RadiowaveDesigner.Infrastructure.Models.Responses;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Mappings;

public interface IPlacesMapper
{
    IEnumerable<Places> Map(IEnumerable<PlacesResponse> placesResponses);
}