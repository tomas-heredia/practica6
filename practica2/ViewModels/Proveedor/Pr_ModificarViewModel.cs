using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class Pr_ModificarViewModel {
        [Required]
        public int id {get;set;}
        
        [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string nombre{get;set;}
        
        [Required( ErrorMessage = "Campo Requerido.")][DataType(DataType.Date, ErrorMessage = "Formato invalido.")] 
        public DateTime fechaAlta{get;set;}
    }
        
}