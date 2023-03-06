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
    public class ClienteController:Controller {
        private readonly ILogger<ClienteController> _logger;
        
        private  List<Cliente> Clientes;
        private readonly IMapper _mapper;
        
        private readonly IRepoClientes _repClientes;
        public ClienteController(ILogger<ClienteController> logger,IRepoClientes repClientes, IMapper mapper)
        {
            _logger = logger;
            
            _repClientes = repClientes;
            _mapper = mapper;
        }

        public IActionResult Index()
        {   
          if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Cliente cliente = new Cliente();
                C_IndexViewModel modelo = _mapper.Map<C_IndexViewModel>(cliente);
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
        public IActionResult addCliente(C_IndexViewModel nuevo)
        {
            
                
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                Cliente Cliente_ = _mapper.Map<Cliente>(nuevo);

                try
                {
                    _repClientes.cargarCliente(Cliente_);
                    
                    Clientes = _repClientes.ConsultaCliente();
                }
                catch (System.Exception e)
                {
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
                
                return View("ListarClientes", _mapper.Map<List<C_ListarViewModel>>(Clientes));
            
                
               
                
            }  
            

        }

         [HttpPost]
        public IActionResult bajaCliente(int id){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                    List<Cliente> Clientes = new List<Cliente>();
                    try
                    {
                        _repClientes.EliminarCliente(id);
                        Clientes = _repClientes.ConsultaCliente();
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }
                    
                
                    return View("ListarClientes", _mapper.Map<List<C_ListarViewModel>>(Clientes));
                    
                    
               
                
            }  
                    
                
            
              
            }

            [HttpPost]
        public IActionResult ModificarCliente(int id){
                if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                Cliente nuevo = new Cliente();
                try
                    {
                        
                        nuevo = _repClientes.TomarCliente(id);
                    
                        
                    }
                    catch (System.Exception e)
                    {
                        
                        _logger.LogError(e.ToString());
                        return RedirectToAction("Index","Error");
                    }        
                    return View("ModificarCliente", _mapper.Map<C_ModificarViewModel>(nuevo));
                    
                
               
                
            }  

            
        }

        [HttpPost]
        public IActionResult Actualizar(C_ModificarViewModel actualizado){
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_UserName)) 
                && string.IsNullOrEmpty(HttpContext.Session.GetString(UsuarioController.Usuario_Id) )){
                
                return RedirectToAction("Index","Usuario"); 
            }else
            {
                
                
                Cliente nuevo = _mapper.Map<Cliente>(actualizado);
                try
                {
                    
                   _repClientes.ActualizarCliente(nuevo);
                   Clientes = _repClientes.ConsultaCliente();
                    
                }
                catch (System.Exception e)
                {
                    
                    _logger.LogError(e.ToString());
                    return RedirectToAction("Index","Error");
                }
               
            
                
                return View("ListarClientes", _mapper.Map<List<C_ListarViewModel>>(Clientes));
                
               
                
            }  

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}