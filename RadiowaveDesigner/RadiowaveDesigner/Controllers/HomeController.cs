using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Modeling.Automation;
using RadiowaveDesigner.Services.Builders;

namespace RadiowaveDesigner.Controllers;

public class HomeController : Controller
{
    private readonly IHomeViewModelBuilder _homeViewModelBuilder;
    private readonly IUserConfigurationRepository _userConfigurationRepository;
    private readonly IBaseStationsAutomationService _baseStationsAutomationService;

    public HomeController(
        IHomeViewModelBuilder homeViewModelBuilder,
        IUserConfigurationRepository userConfigurationRepository,
        IBaseStationsAutomationService baseStationsAutomationService)
    {
        _homeViewModelBuilder = homeViewModelBuilder;
        _userConfigurationRepository = userConfigurationRepository;
        _baseStationsAutomationService = baseStationsAutomationService;
    }

    public async Task<IActionResult> Index()
    {
        var homeView =  await _homeViewModelBuilder.Get();
        return View(homeView);
    }

    public async Task<IActionResult> ChangeExistingBaseStationsVisibility()
    {
        await _userConfigurationRepository.ChangeShowExistingBaseStationsStatus();
        await _baseStationsAutomationService.RestoreAutomatedPlacement();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> ProcessAutomatedPlacement()
    {
        await _baseStationsAutomationService.ProcessAutomatedPlacement();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> RestoreAutomatedPlacement()
    {
        await _baseStationsAutomationService.RestoreAutomatedPlacement();
        return RedirectToAction("Index", "Home");
    }
}