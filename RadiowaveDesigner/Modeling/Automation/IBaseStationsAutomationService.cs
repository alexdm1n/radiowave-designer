using System.Threading.Tasks;

namespace RadiowaveDesigner.Modeling.Automation;

public interface IBaseStationsAutomationService
{
    Task ProcessAutomatedPlacement();

    Task RestoreAutomatedPlacement();
}