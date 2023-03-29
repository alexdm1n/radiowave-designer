using Microsoft.AspNetCore.Mvc;

namespace RadiowaveDesigner.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
}