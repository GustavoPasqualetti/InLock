using InLock.Domain;
using InLock.Interface;
using System.Data.SqlClient;

namespace InLock.Repositores
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string StringConexao = "Data source = NOTE02-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";
        private string query;
        private SqlConnection connection;

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = new List<TipoUsuarioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";
                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tiposUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString(),
                        };

                        //adiciona cada objeto dentro da lista
                        listaTipoUsuario.Add(tiposUsuario);
                    }
                    return listaTipoUsuario;
                }
            }
        }
    }
}
