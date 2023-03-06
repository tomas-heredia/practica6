using Modelos;

using Microsoft.Data.Sqlite;
namespace Repo
{
    public class RepoProveedor:IRepoProveedor {
        
        //conexion con db
        string connectionString = "Data Source= Base/practica2.db;Cache=Shared";
        public RepoProveedor(){
        
        }

        public void cargarProveedor(Proveedor Proveedor){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Proveedores (Nombre,FechaDeAlta) VALUES (@nom, @fec)", conexion);

                insertar.Parameters.AddWithValue("@nom", Proveedor.nombre);
                insertar.Parameters.AddWithValue("@fec", Proveedor.fechaAlta);
                
                insertar.ExecuteReader();
                conexion.Close();
                
                
            }

        }
        public List<Proveedor> ConsultaProveedor(){
            List<Proveedor> ListaProveedors = new List<Proveedor>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Proveedores WHERE Activo = 1", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {                                                         
                        ListaProveedors.Add(new Proveedor(query.GetInt32(0), query.GetString(1), query.GetDateTime(2),query.GetBoolean(3)  ));
                    }
                conexion.Close();
                }
            return ListaProveedors;
        } 

         public void EliminarProveedor(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("UPDATE Proveedores SET Activo = 0 WHERE IdProveedor = @Id", conexion);
                select.Parameters.AddWithValue("@Id",id);
                
                select.ExecuteReader();
                conexion.Close();
                
                
                
            }


        }

        public void ActualizarProveedor(Proveedor Proveedor){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Proveedores SET Nombre = @nom, FechaDeAlta = @fec  WHERE IdProveedor = @Id", conexion);
                    select.Parameters.AddWithValue("@nom", Proveedor.nombre);
                    select.Parameters.AddWithValue("@fec", Proveedor.fechaAlta);
                    
                    select.Parameters.AddWithValue("@Id",Proveedor.id);
                    
                    select.ExecuteNonQuery();
                    conexion.Close();
                        
                    
            }
        }

        public Proveedor TomarProveedor(int id){
            
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    Proveedor nuevoProveedor = new Proveedor();
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Proveedores where IdProveedor = @Id ", conexion);
                 select.Parameters.AddWithValue("@Id",id);
                var query = select.ExecuteReader();
                while (query.Read())
                {

                                                               
                    nuevoProveedor = new Proveedor(query.GetInt32(0), query.GetString(1),query.GetDateTime(2) , query.GetBoolean(3)   );
                }   
                conexion.Close();
                return nuevoProveedor;
                }
        }
        
    }
}

//DateOnly.FromDateTime() para pasar de dateTime a dateOnly