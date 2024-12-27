using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS_ASP.Models;
using NS_ASP.Services.Interfaces;

namespace NS_ASP.Controllers;

public class NSController : Controller
{
    private readonly ITranslationService translationService;

    public NSController(ITranslationService translationService)
    {
        this.translationService = translationService;
    }

    public IActionResult Index(string result = "-1")
    {
        return View("Index", result); 
    }
    [HttpPost]
    public IActionResult Translation(string number, int currentSystem, int system)
    {
        var result = translationService.Translate(number, currentSystem, system);
        return View("Index", result);
    }
}
