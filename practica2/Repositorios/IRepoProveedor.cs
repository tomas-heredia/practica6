using Modelos;

namespace Repo;
public interface IRepoProveedor
{
    void cargarProveedor(Proveedor Proveedor);
    void EliminarProveedor(int id);
    List<Proveedor> ConsultaProveedor();
    Proveedor TomarProveedor(int id);
    void ActualizarProveedor(Proveedor Proveedor);
}