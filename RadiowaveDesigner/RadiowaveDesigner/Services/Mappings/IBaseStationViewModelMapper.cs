using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Services.Mappings;

internal interface IBaseStationViewModelMapper
{
    BaseStationViewModel Map(BaseStationConfiguration config);
}