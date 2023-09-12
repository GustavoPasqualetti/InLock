using InLock.Domain;
using InLock.Interface;
using System.Data.SqlClient;

namespace InLock.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data source = NOTE02-S14; Initial Catalog = inlock_games; User Id = sa; pwd = Senai@134";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario,IdTipoUsuario, Email FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);


                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Email = rdr["Email"].ToString(),
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
