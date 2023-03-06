using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class P_ModificarViewModel {
        
         public int id {get;set;}

        [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string descripcion {get;set;}

        [Range(2,10, ErrorMessage = "El valor no esta en el rango de 2,10.")]
        public int precio {get;set;}
    }
}