using RadiowaveDesigner.Infrastructure.Models.Responses;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Mappings;

internal class PlacesMapper : IPlacesMapper
{
    private readonly IPlaceMapper _placeMapper;

    public PlacesMapper(IPlaceMapper placeMapper)
    {
        _placeMapper = placeMapper;
    }

    public IEnumerable<Places> Map(IEnumerable<PlacesResponse> placesResponses)
    {
        return placesResponses.Select(_placeMapper.Map);
    }
}