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
    public class EmpleadoController:Controller {
        private readonly ILogger<EmpleadoController> _logger;
        
        private  List<Empleado> Empleados;
        private readonly IMapper _mapper;
        
        private readonly IRepoEmpleados _repEmpleados;
        public EmpleadoController(ILogger<EmpleadoController> logger,IRepoEmpleados repEmpleados, IMapper mapper)
        {
            _logger = logger;
            
            _repEmpleados = repEmpleados;
            _mapper = mapper;
        }

        public IActionResult Index()
        {   
          if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Empleado Empleado = new Empleado();
                E_IndexViewModel modelo = _mapper.Map<E_IndexViewModel>(Empleado);
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
        public IActionResult addEmpleado(E_IndexViewModel nuevo)
        {
            
                
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                Empleado Empleado_ = _mapper.Map<Empleado>(nuevo);

                try
                {
                    _repEmpleados.cargarEmpleado(Empleado_);
                    
                    Empleados = _repEmpleados.ConsultaEmpleado();
                }
                catch (System.Exception e)
                {
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
                
                return View("ListarEmpleados", _mapper.Map<List<E_ListarViewModel>>(Empleados));
            
                
               
                
            }  
            

        }

         [HttpPost]
        public IActionResult bajaEmpleado(int id){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                    List<Empleado> Empleados = new List<Empleado>();
                    try
                    {
                        _repEmpleados.EliminarEmpleado(id);
                        Empleados = _repEmpleados.ConsultaEmpleado();
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }
                    
                
                    return View("ListarEmpleados", _mapper.Map<List<E_ListarViewModel>>(Empleados));
                    
                    
               
                
            }  
                    
                
            
              
            }

            [HttpPost]
        public IActionResult ModificarEmpleado(int id){
                if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Empleado nuevo = new Empleado();
                try
                    {
                        
                        nuevo = _repEmpleados.TomarEmpleado(id);
                    
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }        
                    return View("Modificar", _mapper.Map<E_ModificarViewModel>(nuevo));
                    
                
               
                
            }  

            
        }

        [HttpPost]
        public IActionResult Actualizar(E_ModificarViewModel actualizado){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                
                Empleado nuevo = _mapper.Map<Empleado>(actualizado);
                try
                {
                    
                   _repEmpleados.ActualizarEmpleado(nuevo);
                   Empleados = _repEmpleados.ConsultaEmpleado();
                    
                }
                catch (System.Exception e)
                {
                    
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
               
            
                
                return View("ListarEmpleados", _mapper.Map<List<E_ListarViewModel>>(Empleados));
                
               
                
            }  

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}