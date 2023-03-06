using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class U_ModificarViewModel {
        
        public int id {get;set;}
        
        [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string nombre {get;set;}
        
        [Phone( ErrorMessage = "Formato invalido.")]
        public int telefono{get;set;}
        

    }
}