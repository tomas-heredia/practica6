namespace Modelos
{
    public class Empleado {
        public int id {get;set;}
        public string nombre{get;set;}
        public string apellido{get;set;}
        public DateTime nacimiento{get;set;}
        public string direccion{get;set;}
        public int telefono{get;set;}
        public bool activo{get;set;}

        public Empleado(int id,string nombre,string apellido,DateTime nacimiento,string direccion,int telefono, bool activo){
           this.id = id;
           this.nombre = nombre;
           this.apellido = apellido;
           this.direccion = direccion;
           this.telefono = telefono;
           this.activo = activo;
        }
        public Empleado(){}
    }

}