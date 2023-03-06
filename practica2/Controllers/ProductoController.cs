using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practica2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Modelos;
using ViewModels;
using Mappers;
using Repo;
using AutoMapper;
// Para session
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace practica.Controllers
{
    public class ProductoController:Controller {
        private readonly ILogger<ProductoController> _logger;
        
        private  List<Producto> Productos;
        private readonly IMapper _mapper;
        
        private readonly IRepoProductos _repProductos;
        public ProductoController(ILogger<ProductoController> logger,IRepoProductos repProductos, IMapper mapper)
        {
            _logger = logger;
            
            _repProductos = repProductos;
            _mapper = mapper;
        }

        public IActionResult Index()
        {   
          if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Producto Producto = new Producto();
                P_IndexViewModel modelo = _mapper.Map<P_IndexViewModel>(Producto);
                return View(modelo);
                
            }  

            
           
        }
        [HttpPost]
        public IActionResult AHome(){
           if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                return RedirectToAction("Index","Home"); 
            } 
        }

        [HttpPost]
        public IActionResult addProducto(P_IndexViewModel nuevo)
        {
            
                
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                Producto Producto_ = _mapper.Map<Producto>(nuevo);

                try
                {
                    _repProductos.cargarProducto(Producto_);
                    
                    Productos = _repProductos.ConsultaProducto();
                }
                catch (System.Exception e)
                {
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
                
                return View("ListarProductos", _mapper.Map<List<P_ListarViewModel>>(Productos));
            
                
               
                
            }  
            

        }

         [HttpPost]
        public IActionResult bajaProducto(int id){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                    List<Producto> Productos = new List<Producto>();
                    try
                    {
                        _repProductos.EliminarProducto(id);
                        Productos = _repProductos.ConsultaProducto();
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }
                    
                
                    return View("ListarProductos", _mapper.Map<List<P_ListarViewModel>>(Productos));
                    
                    
               
                
            }  
                    
                
            
              
            }

            [HttpPost]
        public IActionResult ModificarProducto(int id){
                if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Producto nuevo = new Producto();
                try
                    {
                        
                        nuevo = _repProductos.TomarProducto(id);
                    
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }        
                    return View("Modificar", _mapper.Map<P_ModificarViewModel>(nuevo));
                    
                
               
                
            }  

            
        }

        [HttpPost]
        public IActionResult Actualizar(P_ModificarViewModel actualizado){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                
                Producto nuevo = _mapper.Map<Producto>(actualizado);
                try
                {
                    
                   _repProductos.ActualizarProducto(nuevo);
                   Productos = _repProductos.ConsultaProducto();
                    
                }
                catch (System.Exception e)
                {
                    
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
               
            
                
                return View("ListarProductos", _mapper.Map<List<P_ListarViewModel>>(Productos));
                
               
                
            }  

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}