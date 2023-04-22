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

    public async Task<IActionResult> Add(BaseStationConfiguration baseStationConfiguration)
    {
        await _configurationService.Add(baseStationConfiguration);
        return RedirectToAction("Configuration", "Configuration");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _configurationService.Delete(id);
        return RedirectToAction("Configuration", "Configuration");
    }
}