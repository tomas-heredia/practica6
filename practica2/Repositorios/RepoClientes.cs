using Modelos;

using Microsoft.Data.Sqlite;
namespace Repo
{
    public class RepoClientes:IRepoClientes {
        
        //conexion con db
        string connectionString = "Data Source= Base/practica2.db;Cache=Shared";
        public RepoClientes(){
        
        }

        public void cargarCliente(Cliente Cliente){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Clientes (Apellido,Nombre,Direccion,Telefono,FechaDeNacimiento) VALUES (@ape,@nom, @dire,@tel, @fec)", conexion);
                insertar.Parameters.AddWithValue("@ape", Cliente.apellido);
                insertar.Parameters.AddWithValue("@nom", Cliente.nombre);
                insertar.Parameters.AddWithValue("@dire", Cliente.direccion);
                insertar.Parameters.AddWithValue("@tel", Cliente.telefono);
                insertar.Parameters.AddWithValue("@fec", Cliente.nacimiento);
                
                insertar.ExecuteReader();
                conexion.Close();
                
                
            }

        }
        public List<Cliente> ConsultaCliente(){
            List<Cliente> ListaClientes = new List<Cliente>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Clientes WHERE Activo = 1", conexion);
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
                        ListaClientes.Add(new Cliente(query.GetInt32(0), query.GetString(1), query.GetString(2),fecha ,direccion,Telefono,Convert.ToInt32( query.GetBoolean(6))  ));
                    }
                conexion.Close();
                }
            return ListaClientes;
        } 

         public void EliminarCliente(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("UPDATE Clientes SET Activo = 0 WHERE IdCLiente = @Id", conexion);
                select.Parameters.AddWithValue("@Id",id);
                
                select.ExecuteReader();
                conexion.Close();
                
                
                
            }


        }

        public void ActualizarCliente(Cliente Cliente){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Clientes SET Apellido = @ape, Nombre = @nom, Direccion = @dire,FechaDeNacimiento = @fec , Telefono = @tel WHERE IdCLiente = @Id", conexion);
                    select.Parameters.AddWithValue("@nom", Cliente.nombre);
                    select.Parameters.AddWithValue("@dire", Cliente.direccion);
                    select.Parameters.AddWithValue("@tel", Cliente.telefono);
                    select.Parameters.AddWithValue("@ape", Cliente.apellido);
                    select.Parameters.AddWithValue("@fec", Cliente.nacimiento);
                    
                    select.Parameters.AddWithValue("@Id",Cliente.id);
                    
                    select.ExecuteNonQuery();
                    conexion.Close();
                        
                    
            }
        }

        public Cliente TomarCliente(int id){
            
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    Cliente nuevoCliente = new Cliente();
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Clientes where IdCLiente = @Id ", conexion);
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
                    nuevoCliente = new Cliente(query.GetInt32(0), query.GetString(1), query.GetString(2),fecha ,direccion ,Telefono,Convert.ToInt32( query.GetBoolean(6))   );
                }   
                conexion.Close();
                return nuevoCliente;
                }
        }
        
    }
}