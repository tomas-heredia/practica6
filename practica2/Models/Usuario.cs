
namespace Modelos
{
    public class Usuario {
        public int id {get;set;}
        public string nombre {get;set;}
        public int telefono{get;set;}
        public int activo {get;set;}

        public Usuario(int id, string nombre, int telefono, int activo){
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.activo = activo;
        }
        public Usuario(){}
    }
}