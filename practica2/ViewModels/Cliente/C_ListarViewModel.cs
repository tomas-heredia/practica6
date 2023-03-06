using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class C_ListarViewModel {
        public int id{get;set;}

        public string apellido {get;set;}

        public string nombre {get;set;}

        public DateTime nacimiento {get;set;}
        
        public string direccion {get;set;}
        public int telefono {get;set;}

        public int activo {get;set;}
    }
}