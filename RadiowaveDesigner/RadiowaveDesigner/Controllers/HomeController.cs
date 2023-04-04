using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Services;
using RadiowaveDesigner.Services.Builders;

namespace RadiowaveDesigner.Controllers;

public class HomeController : Controller
{
    private readonly IHomeViewModelBuilder _homeViewModelBuilder;

    public HomeController(IHomeViewModelBuilder homeViewModelBuilder)
    {
        _homeViewModelBuilder = homeViewModelBuilder;
    }

    public async Task<IActionResult> Index()
    {
        var homeView = _homeViewModelBuilder.Get();
        return View(homeView);
    }
}