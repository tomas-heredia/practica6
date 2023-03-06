using Modelos;

using Microsoft.Data.Sqlite;
namespace Repo
{
    public class RepoUsuario:IRepoUsuario {
        
        //conexion con db
        string connectionString = "Data Source= Base/practica2.db;Cache=Shared";
        public RepoUsuario(){
        
        }
        public bool verificarUsuario(Usuario Usuario){
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
            {
                conexion.Open();
                SqliteCommand insertar = new("Select * from Usuarios WHERE NombreUsuario= @nombre and IdUsuario = @id",
                 conexion);
               
                insertar.Parameters.AddWithValue("@nombre", Usuario.nombre);
                insertar.Parameters.AddWithValue("@id", Usuario.id);
                
                
                    
                var query = insertar.ExecuteReader();
                conexion.Close();
                bool resultado = false;
                while (query.Read())
                {
                    resultado = true;
                }
                    return resultado;
                   
                
            }

        }

        public List<Usuario> ConsultaUsuario(){
            List<Usuario> ListaUsuarios = new List<Usuario>();
        
            using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Usuarios", conexion);
                var query = select.ExecuteReader();
                while (query.Read())
                    {   


                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }

                                                                //ID,           Nombre                    
                        ListaUsuarios.Add(new Usuario(query.GetInt32(0), query.GetString(1),Telefono,Convert.ToInt32( query.GetBoolean(3))  ));
                    }
                conexion.Close();
                }
            return ListaUsuarios;
        } 





        public Usuario TomarUsuario(int id){
            
             using (SqliteConnection conexion = new SqliteConnection(connectionString)) 
                {
                    Usuario nuevoUsuario = new Usuario();
                conexion.Open();
                SqliteCommand select = new SqliteCommand("SELECT * FROM Usuarios where IdUsuario = @Id", conexion);
                 select.Parameters.AddWithValue("@Id",id);
                var query = select.ExecuteReader();
                while (query.Read())
                {
                    var Telefono = 0;
                    if (query["Telefono"] != System.DBNull.Value)
                    {
                        Telefono=Convert.ToInt32( query["Telefono"]);
                    }
                                                //ID,              Nombre                    
                    nuevoUsuario = new Usuario(query.GetInt32(0), query.GetString(1),Telefono,Convert.ToInt32( query.GetBoolean(3))   );
                }   
                conexion.Close();
                return nuevoUsuario;
                }
        }
    }
}