using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcademiaAllFights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoArteMarcialController : ControllerBase
    {

        private readonly IRepository _repository;

        public AlunoArteMarcialController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var artesMarciais = await _repository.GetAlunoArteMarcialAlunoAsync(id);

            if (artesMarciais == null) return NotFound("Nenhuma arte marcial cadastrada");

            return Ok(artesMarciais);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlunoArteMarcial alunoArteMarcial)
        {
            _repository.Add(alunoArteMarcial);
            if (await _repository.SaveChangesAsync()) return Created("Arte marcial adicionada", alunoArteMarcial);

            return BadRequest("Erro ao adicionar arte marcial");
        }

        [HttpDelete("aluno/{idAluno}/artemarcial/{idArteMarcial}")]
        public async Task<IActionResult> Delete(int idAluno, int idArteMarcial)
        {
            var arteMarcial = await _repository.GetAlunoArteMarcialAsync(idAluno, idArteMarcial);
            if (arteMarcial == null) return NotFound("Erro ao remover Arte marcial");
            _repository.Delete(arteMarcial);
            if (await _repository.SaveChangesAsync()) return Ok("Arte marcial removida com sucesso!");
            return BadRequest("Erro ao remover Arte marcial");
        }
    }
}
