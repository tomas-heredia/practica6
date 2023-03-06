using Modelos;

namespace Repo;
public interface IRepoEmpleados
{
    void cargarEmpleado(Empleado Empleado);
    void EliminarEmpleado(int id);
    List<Empleado> ConsultaEmpleado();
    Empleado TomarEmpleado(int id);
    void ActualizarEmpleado(Empleado Empleado);
}