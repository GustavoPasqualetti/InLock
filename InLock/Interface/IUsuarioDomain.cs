using InLock.Domain;

namespace InLock.Interface
{
    public interface IUsuarioDomain
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
