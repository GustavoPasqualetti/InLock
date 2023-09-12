using InLock.Domain;
using InLock.Interface;
using System.Data.SqlClient;

namespace InLock.Repositores
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE02-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";
        
  
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "INSERT INTO Jogo(IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES(@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor )";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descriao);
                    cmd.Parameters.AddWithValue("DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Estudio.IdEstudio, Jogo.Nome, Descricao, Jogo.DataLancamento FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";
                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogos = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            Nome = rdr["Nome"].ToString(),

                            Descricao = rdr["Descricao"].ToString(),

                            DataLancamento = rdr["DataLancamento"].ToString(),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        //adiciona cada objeto dentro da lista
                        listaJogos.Add(jogos);
                    }
                    return listaJogos;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }



      
    }
}
