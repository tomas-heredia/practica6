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
    public class UsuarioController:Controller {
        public static string Usuario_UserName = "_Name";
        public static string Usuario_Id= "_Id";
         private readonly ILogger<UsuarioController> _logger;
        
        private  List<Usuario> Usuarios;
        private readonly IMapper _mapper;
        
        private readonly IRepoUsuario _repUsuarios;
        public UsuarioController(ILogger<UsuarioController> logger,IRepoUsuario repUsuarios, IMapper mapper)
        {
            _logger = logger;
            
            _repUsuarios = repUsuarios;
            _mapper = mapper;
        }

         public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ControlUsuario(U_IndexViewModel cargado)
        {
            
            
            Usuario Usuario_ = _mapper.Map<Usuario>(cargado);
            var existe = false;
            try
            {
                existe = _repUsuarios.verificarUsuario(Usuario_);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.ToString());
                return RedirectToAction("Index","ErrorUsuario");
            }

            if (existe )
            {
                Usuario nuevo = new Usuario();
                nuevo = _repUsuarios.TomarUsuario(Usuario_.id);
                HttpContext.Session.SetString(Usuario_UserName, nuevo.nombre);
                HttpContext.Session.SetInt32(Usuario_Id, nuevo.id);

                return RedirectToAction("Index","Home");
            }else
            {
                
                return RedirectToAction("Index","ErrorUsuario");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}   
