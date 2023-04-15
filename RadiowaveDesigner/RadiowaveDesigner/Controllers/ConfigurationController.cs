using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Models.Models;
using RadiowaveDesigner.ViewModels;

namespace RadiowaveDesigner.Controllers;

public class ConfigurationController : Controller
{
    public async Task<IActionResult> Configuration()
    {
        var viewModel = new ConfigurationViewModel()
        {
            BaseStationConfiguration = new BaseStationConfiguration()
            {
                FrequencyInHz = 5000,
                Height = 40,
            },
            CoordinatesConfigurations = new[]
            {
                new CoordinatesConfiguration()
                {
                    Value = "53.94294178325, 27.610945550371945",
                },
                new CoordinatesConfiguration()
                {
                    Value = "53.8829441716099, 27.4818561949032",
                }
            }
        };

        return View(viewModel);
    }

    public async Task<IActionResult> UpdateBaseStationConfig(BaseStationConfiguration baseStationConfiguration)
    {
        return RedirectToAction("Configuration", "Configuration");
    }

    public async Task<IActionResult> AddCoordinates(string coordinates)
    {
        return RedirectToAction("Configuration", "Configuration");
    }

    public async Task<IActionResult> DeleteCoordinates(int id)
    {
        return RedirectToAction("Configuration", "Configuration");
    }
}