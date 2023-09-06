using InLock.Domain;

namespace InLock.Interface
{
    public interface IJogoRepository
    {
        void Cadastrar(JogoDomain novoJogo);
        List<JogoDomain> ListarTodos();
        JogoDomain BuscarPorId(int id);
        void AtualizarIdCorpo(JogoDomain Jogo);
        void Deletar(int id);
    }
}
