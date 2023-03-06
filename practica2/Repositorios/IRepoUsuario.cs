using Modelos;

namespace Repo;
public interface IRepoUsuario
{
    bool verificarUsuario(Usuario usuario);
    List<Usuario> ConsultaUsuario();
    Usuario TomarUsuario(int id);

}