
namespace Modelos
{
    public class Cliente {
        public int id {get;set;}
        public string apellido {get;set;}
        public string nombre {get;set;}
        public DateTime nacimiento {get;set;}
        public string direccion {get;set;}
        public int telefono {get;set;}
        public int activo {get;set;}

        public Cliente(int id, string apellido, string nombre, DateTime nacimiento,string direccion,int telefono, int activo){
            this.id = id;
            this.apellido = apellido;
            this.nombre = nombre;
            this.nacimiento = nacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
            this.activo = activo;
        }
        public Cliente(){}
    }
}