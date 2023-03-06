namespace Modelos
{
    public class Proveedor {
        public int id {get;set;}
        public string nombre{get;set;}
        public DateTime fechaAlta{get;set;}
        public bool activo {get;set;}
        public Proveedor(int id, string nombre, DateTime fechaAlta, bool action){
            this.id = id;
            this.nombre = nombre;
            this.fechaAlta = fechaAlta;
            this.activo = action;
        }
        public Proveedor(){}
    }
}