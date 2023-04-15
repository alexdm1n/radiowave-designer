using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.Services.Builders;
using RadiowaveDesigner.Services.Configuration;

namespace RadiowaveDesigner.Controllers;

public class ConfigurationController : Controller
{
    private readonly IConfigurationViewModelBuilder _configurationViewModelBuilder;
    private readonly IConfigurationService _configurationService;

    public ConfigurationController(
        IConfigurationViewModelBuilder configurationViewModelBuilder,
        IConfigurationService configurationService)
    {
        _configurationViewModelBuilder = configurationViewModelBuilder;
        _configurationService = configurationService;
    }

    public async Task<IActionResult> Configuration()
    {
        var config = await _configurationViewModelBuilder.Build();
        return View(config);
    }

    public async Task<IActionResult> UpdateBaseStationConfig(BaseStationConfiguration baseStationConfiguration)
    {
        await _configurationService.UpdateBaseStationConfig(baseStationConfiguration);
        return RedirectToAction("Configuration", "Configuration");
    }

    public async Task<IActionResult> AddCoordinates(string coordinates)
    {
        await _configurationService.AddCoordinates(coordinates);
        return RedirectToAction("Configuration", "Configuration");
    }

    public async Task<IActionResult> DeleteCoordinates(int id)
    {
        await _configurationService.DeleteCoordinates(id);
        return RedirectToAction("Configuration", "Configuration");
    }
}