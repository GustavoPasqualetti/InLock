using InLock.Domain;
using InLock.Interface;
using InLock.Repositores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InLock.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou Senha Inválidos !");
                }

                //Caso encontre o usuario , prossegue para a criacao do token

                //1 - Definir as informacoes(claims) que serao fornecidos no token (PAYLOAD)
                var claims = new[]
                {
                    //formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.IdTipoUsuario.ToString()),

                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                //2 - Definir a chave de acesso ao token

                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

                //3 - Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                //4- Gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token 
                    issuer: "InLock",

                    //destinatario do token
                    audience: "InLock",

                    //dados definidos nas claims(informacoes)
                    claims: claims,

                    //tempo de expiracao do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //5 - retornar o token criado
                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }

}
