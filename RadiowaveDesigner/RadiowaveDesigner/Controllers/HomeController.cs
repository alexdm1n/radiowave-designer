using Microsoft.AspNetCore.Mvc;
using RadiowaveDesigner.Services;

namespace RadiowaveDesigner.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _homeService;

    public HomeController(IHomeService homeService)
    {
        _homeService = homeService;
    }

    public async Task<IActionResult> Index()
    {
        var homeView = _homeService.Get();
        return View(homeView);
    }
}