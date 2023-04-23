using RadiowaveDesigner.Modeling.SuiModel.Services.Calculation;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Calculations;

internal class PropagationRangeCalculator : IPropagationRangeCalculator
{
    private readonly ISuiModelCalculator _suiModelCalculator;

    public PropagationRangeCalculator(ISuiModelCalculator suiModelCalculator)
    {
        _suiModelCalculator = suiModelCalculator;
    }

    public int? Calculate(BaseStationConfiguration? config)
    {
        if (config == null)
        {
            return null;
        }

        return _suiModelCalculator.CalculatePropagationRange(config);
    }
}