using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class P_ListarViewModel {
    
         public int id {get;set;}
      
        public string descripcion {get;set;}
       
        public int precio {get;set;}
        
        public bool activo {get;set;}
    }
}