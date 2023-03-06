using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using practica2.Models;



namespace practica.Controllers;

public class ErrorUsuarioController : Controller
{
    private readonly ILogger<ErrorUsuarioController> _logger;

    public ErrorUsuarioController(ILogger<ErrorUsuarioController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
      
            return View();
            
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}