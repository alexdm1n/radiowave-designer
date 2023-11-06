using RadiowaveDesigner.Models.Models;

namespace RadiowaveDesigner.Services.Mappings;

internal interface ICategoryMapper
{
    Category Map(string categoryName);
}