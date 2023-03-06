using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using practica2.Models;
using practica.Controllers;
namespace practica2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
        && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
            return RedirectToAction("Index","Usuario"); 
        }else
        {
            return View();
            
        }
    }
    [HttpPost]
    public IActionResult IndexCliente(){
       
            
           
        return RedirectToAction("Index","Cliente");
    }
     [HttpPost]
    public IActionResult IndexEmpleado(){
       
            
           
        return RedirectToAction("Index","Empleado");
    }
        [HttpPost]
    public IActionResult IndexProducto(){
       
            
           
        return RedirectToAction("Index","Producto");
    }
    [HttpPost]
    public IActionResult IndexProveedor(){
       
            
           
        return RedirectToAction("Index","Proveedor");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
