using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class Pr_ListarViewModel {
       
        public int id {get;set;}
        
        public string nombre{get;set;}
        
        public DateTime fechaAlta{get;set;}
        
        public bool activo {get;set;}
    }
        
}