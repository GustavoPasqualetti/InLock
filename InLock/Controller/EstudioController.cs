using InLock.Domain;
using InLock.Interface;
using InLock.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace InLock.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository= new EstudioRepository();
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaestudios = _estudioRepository.ListarEstudios();
                return Ok(listaestudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                _estudioRepository.Deletar(Id);

                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
