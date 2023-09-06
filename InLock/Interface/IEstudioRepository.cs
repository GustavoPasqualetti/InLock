using InLock.Domain;

namespace InLock.Interface
{
    public interface IEstudioRepository
    {
        void Cadastrar(EstudioDomain novoEstudio);

        List<EstudioDomain> ListarEstudios();

        void Deletar(int id);
    }
}
