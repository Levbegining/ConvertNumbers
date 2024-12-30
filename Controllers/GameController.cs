using System;
using Microsoft.AspNetCore.Mvc;

namespace NS_ASP.Controllers;

public class GameController : Controller
{
    public IActionResult Index(){
        return View();
    }
    [HttpGet]
    public IActionResult Play(){
        return View();
    }
}
