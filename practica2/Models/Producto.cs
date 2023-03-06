namespace Modelos
{
    public class Producto {
        public int id {get;set;}
        public string descripcion {get;set;}
        public int precio {get;set;}
        public bool activo {get;set;}

        public Producto(int id, string descripcion, int precio, bool activo){
            this.id = id;
            this.descripcion = descripcion;
            this.precio = precio;
            this.activo = activo;
        }
        public Producto(){}
    }
}