using Modelos;

namespace Repo;
public interface IRepoProductos
{
    void cargarProducto(Producto Producto);
    void EliminarProducto(int id);
    List<Producto> ConsultaProducto();
    Producto TomarProducto(int id);
    void ActualizarProducto(Producto Producto);
}