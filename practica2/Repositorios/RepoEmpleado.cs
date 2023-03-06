using Modelos;

using Microsoft.Data.Sqlite;
namespace Repo
{
    public class RepoEmpleados:IRepoEmpleados {
        
        //conexion con db
        string connectionString = "Data Source= Base/practica2.db;Cache=Shared";
        public RepoEmpleados(){
        
        }
        public void cargarEmpleado(Empleado Empleado){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Empleados (Apellido,Nombre,Direccion,Telefono,FechaDeNacimiento) VALUES (@ape,@nom, @dire,@tel, @fec)", conexion);
                insertar.Parameters.AddWithValue("@ape", Empleado.apellido);
                insertar.Parameters.AddWithValue("@nom", Empleado.nombre);
                insertar.Parameters.AddWithValue("@dire", Empleado.direccion);
                insertar.Parameters.AddWithValue("@tel", Empleado.telefono);
                insertar.Parameters.AddWithValue("@fec", Empleado.nacimiento);
                
                insertar.ExecuteReader();
                conexion.Close();
                
                
            }

        }
        public List<Empleado> ConsultaEmpleado(){
            List<Empleado> ListaEmpleados = new List<Empleado>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Empleados WHERE Activo = 1", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {   
                    string direccion = "";
                    if (query["Direccion"] != System.DBNull.Value)
                    {
                        direccion = query["Direccion"].ToString();
                    }
                    DateTime fecha = DateTime.Today;
                    if (query["FechaDeNacimiento"] != System.DBNull.Value)
                    {
                        fecha= Convert.ToDateTime(query["FechaDeNacimiento"]);
                    }
                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }

                                                                //ID,          Apellido               Nombre                    
                        ListaEmpleados.Add(new Empleado(query.GetInt32(0), query.GetString(1), query.GetString(2),fecha ,direccion,Telefono,query.GetBoolean(6) ));
                    }
                conexion.Close();
                }
            return ListaEmpleados;
        } 
        public void EliminarEmpleado(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("UPDATE Empleados SET Activo = 0 WHERE IdEmpleado = @Id", conexion);
                select.Parameters.AddWithValue("@Id",id);
                
                select.ExecuteReader();
                conexion.Close();
                
                
                
            }


        }
        public void ActualizarEmpleado(Empleado Empleado){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Empleados SET Apellido = @ape, Nombre = @nom, Direccion = @dire,FechaDeNacimiento = @fec , Telefono = @tel WHERE IdEmpleado = @Id", conexion);
                    select.Parameters.AddWithValue("@nom", Empleado.nombre);
                    select.Parameters.AddWithValue("@dire", Empleado.direccion);
                    select.Parameters.AddWithValue("@tel", Empleado.telefono);
                    select.Parameters.AddWithValue("@ape", Empleado.apellido);
                    select.Parameters.AddWithValue("@fec", Empleado.nacimiento);
                    
                    select.Parameters.AddWithValue("@Id",Empleado.id);
                    
                    select.ExecuteNonQuery();
                    conexion.Close();
                        
                    
            }
        }
        public Empleado TomarEmpleado(int id){
            
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    Empleado nuevoEmpleado = new Empleado();
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Empleados where IdEmpleado = @Id ", conexion);
                 select.Parameters.AddWithValue("@Id",id);
                var query = select.ExecuteReader();
                while (query.Read())
                {
                    string direccion = "";
                    if (query["Direccion"] != System.DBNull.Value)
                    {
                        direccion= query["Direccion"].ToString() ;
                    }
                    DateTime fecha = DateTime.Today;
                    if (query["FechaDeNacimiento"] != System.DBNull.Value)
                    {
                        fecha= Convert.ToDateTime(query["FechaDeNacimiento"]);
                    }
                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }
                                                //ID,          Apellido               Nombre                    
                    nuevoEmpleado = new Empleado(query.GetInt32(0), query.GetString(1), query.GetString(2),fecha ,direccion ,Telefono, query.GetBoolean(6)  );
                }   
                conexion.Close();
                return nuevoEmpleado;
                }
        }
    }
}