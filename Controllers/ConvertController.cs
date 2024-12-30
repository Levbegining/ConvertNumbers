using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS_ASP.Models;
using NS_ASP.Models.ViewModels;
using NS_ASP.Services.Interfaces;

//namespace NS_ASP.Controllers;

public class ConvertController : Controller
{
    private readonly ITranslationService translationService;

    public ConvertController(ITranslationService translationService)
    {
        this.translationService = translationService;
    }
    public ActionResult Translation(string? result = null)
    {
        ViewBag.Result = result;
        return View();
    }
    [HttpPost]
    public IActionResult TranslationPost(TranslateViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Translation", "Convert", new{ result = translationService.Translate(viewModel)});
        }
        
        return View("Translation", viewModel);
    }

}
