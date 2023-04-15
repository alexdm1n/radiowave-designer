namespace RadiowaveDesigner.Services.Calculations;

internal interface IPropagationRangeCalculator
{
    Task<int?> Calculate();
}