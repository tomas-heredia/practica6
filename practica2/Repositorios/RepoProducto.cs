using Modelos;

using Microsoft.Data.Sqlite;
namespace Repo
{
    public class RepoProducto:IRepoProductos {
        
        //conexion con db
        string connectionString = "Data Source= Base/practica2.db;Cache=Shared";
        public RepoProducto(){
        
        }

        public void cargarProducto(Producto Producto){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("INSERT INTO Productos (Descripcion,Precio) VALUES (@des,@pre)", conexion);
                insertar.Parameters.AddWithValue("@des", Producto.descripcion);
                insertar.Parameters.AddWithValue("@pre", Producto.precio);
                

                
                insertar.ExecuteReader();
                conexion.Close();
                
                
            }

        }
        public List<Producto> ConsultaProducto(){
            List<Producto> ListaProductos = new List<Producto>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Productos WHERE Activo = 1", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {   
                    string descripcion = "";
                    if (query["Descripcion"] != System.DBNull.Value)
                    {
                        descripcion = query["Descripcion"].ToString();
                    }


                                                                //ID,                           
                        ListaProductos.Add(new Producto(query.GetInt32(0) ,descripcion,query.GetInt32(2), query.GetBoolean(3))  );
                    }
                conexion.Close();
                }
            return ListaProductos;
        } 

         public void EliminarProducto(int id){
              using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("UPDATE Productos SET Activo = 0 WHERE IdProducto = @Id", conexion);
                select.Parameters.AddWithValue("@Id",id);
                
                select.ExecuteReader();
                conexion.Close();
                
                
                
            }


        }

        public void ActualizarProducto(Producto Producto){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                    conexion.Open();
                    SqliteCommand select = new SqliteCommand("UPDATE Productos SET Descripcion = @des, Precio = @pres, Activo = @act WHERE IdProducto = @Id", conexion);
                    select.Parameters.AddWithValue("@des", Producto.descripcion);
                    select.Parameters.AddWithValue("@pres", Producto.precio);
                    select.Parameters.AddWithValue("@act", Producto.activo);

                    
                    select.Parameters.AddWithValue("@Id",Producto.id);
                    
                    select.ExecuteNonQuery();
                    conexion.Close();
                        
                    
            }
        }

        public Producto TomarProducto(int id){
            
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    Producto nuevoProducto = new Producto();
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Productos where IdProducto = @Id ", conexion);
                 select.Parameters.AddWithValue("@Id",id);
                var query = select.ExecuteReader();
                while (query.Read())
                {
                    string descripcion = "";
                    if (query["Descripcion"] != System.DBNull.Value)
                    {
                        descripcion= query["Descripcion"].ToString() ;
                    }

                                                                 
                    nuevoProducto = new Producto(query.GetInt32(0),descripcion ,query.GetInt32(2), query.GetBoolean(3)  );
                }   
                conexion.Close();
                return nuevoProducto;
                }
        }
        
    }
}