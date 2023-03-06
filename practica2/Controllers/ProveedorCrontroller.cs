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
    public class ProveedorController:Controller {
        private readonly ILogger<ProveedorController> _logger;
        
        private  List<Proveedor> Proveedores;
        private readonly IMapper _mapper;
        
        private readonly IRepoProveedor _repProveedores;
        public ProveedorController(ILogger<ProveedorController> logger,IRepoProveedor repProveedores, IMapper mapper)
        {
            _logger = logger;
            
            _repProveedores = repProveedores;
            _mapper = mapper;
        }

        public IActionResult Index()
        {   
          if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Proveedor Proveedor = new Proveedor();
                Pr_IndexViewModel modelo = _mapper.Map<Pr_IndexViewModel>(Proveedor);
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
        public IActionResult addProveedor(Pr_IndexViewModel nuevo)
        {
            
                
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                Proveedor Proveedor_ = _mapper.Map<Proveedor>(nuevo);

                try
                {
                    _repProveedores.cargarProveedor(Proveedor_);
                    
                    Proveedores = _repProveedores.ConsultaProveedor();
                }
                catch (System.Exception e)
                {
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
                
                return View("ListarProveedor", _mapper.Map<List<Pr_ListarViewModel>>(Proveedores));
            
                
               
                
            }  
            

        }

         [HttpPost]
        public IActionResult bajaProveedor(int id){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                    List<Proveedor> Proveedores = new List<Proveedor>();
                    try
                    {
                        _repProveedores.EliminarProveedor(id);
                        Proveedores = _repProveedores.ConsultaProveedor();
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }
                    
                
                    return View("ListarProveedor", _mapper.Map<List<Pr_ListarViewModel>>(Proveedores));
                    
                    
               
                
            }  
                    
                
            
              
            }

            [HttpPost]
        public IActionResult ModificarProveedor(int id){
                if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Proveedor nuevo = new Proveedor();
                try
                    {
                        
                        nuevo = _repProveedores.TomarProveedor(id);
                    
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }        
                    return View("Modificar", _mapper.Map<Pr_ModificarViewModel>(nuevo));
                    
                
               
                
            }  

            
        }

        [HttpPost]
        public IActionResult Actualizar(Pr_ModificarViewModel actualizado){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                
                Proveedor nuevo = _mapper.Map<Proveedor>(actualizado);
                try
                {
                    
                   _repProveedores.ActualizarProveedor(nuevo);
                   Proveedores = _repProveedores.ConsultaProveedor();
                    
                }
                catch (System.Exception e)
                {
                    
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
               
            
                
                return View("ListarProveedor", _mapper.Map<List<Pr_ListarViewModel>>(Proveedores));
                
               
                
            }  

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}