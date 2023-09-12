using InLock.Domain;

namespace InLock.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
