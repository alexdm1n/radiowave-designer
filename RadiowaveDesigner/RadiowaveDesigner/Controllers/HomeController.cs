using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Services.Builders;

namespace RadiowaveDesigner.Controllers;

public class HomeController : Controller
{
    private readonly IHomeViewModelBuilder _homeViewModelBuilder;
    private readonly IUserConfigurationRepository _userConfigurationRepository;

    public HomeController(
        IHomeViewModelBuilder homeViewModelBuilder, IUserConfigurationRepository userConfigurationRepository)
    {
        _homeViewModelBuilder = homeViewModelBuilder;
        _userConfigurationRepository = userConfigurationRepository;
    }

    public async Task<IActionResult> Index()
    {
        var homeView =  await _homeViewModelBuilder.Get();
        return View(homeView);
    }

    public async Task<IActionResult> ChangeExistingBaseStationsVisibility()
    {
        await _userConfigurationRepository.ChangeShowExistingBaseStationsStatus();
        return RedirectToAction("Index", "Home");
    }
}