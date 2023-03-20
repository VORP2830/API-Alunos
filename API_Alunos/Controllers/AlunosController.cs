using API_Alunos.Models;
using API_Alunos.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                if(alunos == null)
                {
                    return NotFound("Não exitem alunos cadastrados");
                }
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<Aluno>> GetAlunoById(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if(aluno == null)
                {
                    return NotFound($"Aluno com id={id} não encontrado");
                }
                return Ok(aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter aluno com id {id}");
            }
        }
        [HttpGet("AlunosNome")]
        public async Task<ActionResult<Aluno>> GetAlunoByNome([FromQuery] string nome)
        {
            try
            {
                var aluno = await _alunoService.GetAlunosByNome(nome);
                if(aluno == null)
                {
                    return NotFound($"Aluno com o nome {nome} não encontrado");
                }
                return Ok(aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter aluno com nome {nome}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult> Edit(int id,[FromBody] Aluno aluno)
        {
            try
            {
                if(aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno atualizado com sucesso");
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }
        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult> Delete(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno deletado com sucesso");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao deletar aluno com id {id}");
            }
        }
    }
}
