using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NS_ASP.Models;
using NS_ASP.Models.ViewModels;
using NS_ASP.Services.Interfaces;

namespace NS_ASP.Controllers;

public class NSController : Controller
{
    private readonly ITranslationService translationService;

    public NSController(ITranslationService translationService)
    {
        this.translationService = translationService;
    }

    public IActionResult Index()
    {
        return View(); 
    }
    [HttpPost]
    public IActionResult Translation(TranslateViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            // if(viewModel.SystemOfNumber == null)
            // {
            //     viewModel.SystemOfNumber = "10";
            // }

            
            return Content(translationService.Translate(viewModel));
        }
        
        return View(viewModel);
    }
}
