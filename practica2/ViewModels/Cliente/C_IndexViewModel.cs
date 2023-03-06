using System.ComponentModel.DataAnnotations;
//renombrar
namespace ViewModels
{
    public class C_IndexViewModel {

        [Required( ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string apellido {get;set;}

        [Required (ErrorMessage = "Campo Requerido.")][StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string nombre {get;set;}

        [DataType(DataType.Date, ErrorMessage = "Formato invalido.")] 
        public DateTime nacimiento {get;set;}

        [StringLength(100, ErrorMessage = "Cadena demasiado larga.")]
        public string direccion {get;set;}
        
        [Phone( ErrorMessage = "Formato invalido.")]
        public int telefono {get;set;}

    }
}