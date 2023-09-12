using InLock.Domain;

namespace InLock.Interface
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> ListarTodos();
    }
}
