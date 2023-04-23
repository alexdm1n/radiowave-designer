using Microsoft.Extensions.DependencyInjection;
using RadiowaveDesigner.Modeling.SuiModel.Services.Calculation;

namespace RadiowaveDesigner.Modeling;

public static class ModelingModule
{
    public static void AddModelingModule(this IServiceCollection services)
    {
        services.AddTransient<ISuiModelCalculator, SuiModelCalculator>();
    }
}