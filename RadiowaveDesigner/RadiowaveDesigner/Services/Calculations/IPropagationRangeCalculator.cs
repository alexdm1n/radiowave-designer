using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Calculations;

internal interface IPropagationRangeCalculator
{
    int? Calculate(BaseStationConfiguration config);
}