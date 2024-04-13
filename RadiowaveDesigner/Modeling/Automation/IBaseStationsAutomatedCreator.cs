using System.Threading.Tasks;
using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Modeling.Automation;

internal interface IBaseStationsAutomatedCreator
{
    Task PlaceBaseStations(bool includeExistingStations, AreaConfiguration areaConfig);
}