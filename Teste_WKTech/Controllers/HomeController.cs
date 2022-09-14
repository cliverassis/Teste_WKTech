using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teste_WKTech.Models;
using Teste_WKTech.Models.ViewModel;


namespace Teste_WKTech.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Inicio");
    }


    public PartialViewResult Inicio()
    {
        return PartialView();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

