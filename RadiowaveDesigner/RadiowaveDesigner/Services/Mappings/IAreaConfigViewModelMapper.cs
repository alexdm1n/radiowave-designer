using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Mappings;

internal interface IAreaConfigViewModelMapper
{
    AreaConfigViewModel Map(IEnumerable<Coordinate> coordinates);
}