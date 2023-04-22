using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Calculations;

internal class PropagationRangeCalculator : IPropagationRangeCalculator
{
    public int? Calculate(BaseStationConfiguration? config)
    {
        if (config == null)
        {
            return null;
        }

        return 20000;
    }
}