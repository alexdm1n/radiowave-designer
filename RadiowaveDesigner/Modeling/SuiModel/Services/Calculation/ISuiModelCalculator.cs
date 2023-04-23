using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.SuiModel.Services.Calculation;

public interface ISuiModelCalculator
{
    int CalculatePropagationRange(BaseStationConfiguration config);
}