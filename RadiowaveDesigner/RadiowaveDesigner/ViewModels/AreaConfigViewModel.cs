using RadiowaveDesigner.Models;

namespace RadiowaveDesigner.ViewModels;

internal class AreaConfigViewModel
{
    public IEnumerable<CoordinatesModelWithPosition> Coordinates { get; set; }
}