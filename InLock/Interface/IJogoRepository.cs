using InLock.Domain;

namespace InLock.Interface
{
    public interface IJogoRepository
    {
        void Cadastrar(JogoDomain novoJogo);
        List<JogoDomain> ListarTodos();

        void Deletar(int id);
    }
}
