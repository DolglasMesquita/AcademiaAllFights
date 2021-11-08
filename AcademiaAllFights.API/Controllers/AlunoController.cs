using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaAllFights.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;

        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var alunos = _repository.GetAllAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var aluno = _repository.GetAlunoById(id);
            if(aluno == null) return BadRequest("Aluno não encontrado!");

            return Ok(aluno);
        }

        [HttpGet("artemarcial/{id}")]
        public IActionResult GetByArteMarcial(int id) {
            var alunos = _repository.GetAlunosByArteMarcialId(id);

            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno) {
            _repository.Add(aluno);
            if(!_repository.SaveChanges()) return BadRequest("Aluno não cadastrado");

            return Created("Aluno criado com sucesso!", aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno) {
            var alu = _repository.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");
            _repository.Update(aluno);
            if(!_repository.SaveChanges()) return BadRequest("Aluno não atualizado");
            return Ok("Aluno atualizado com sucesso!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno) {
            var alu = _repository.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");
            _repository.Update(aluno);
            if(!_repository.SaveChanges()) return BadRequest("Aluno não atualizado");
            return Ok("Aluno atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            _repository.Delete(aluno);
            if(!_repository.SaveChanges()) return BadRequest("Aluno não removido");
            return Ok("Aluno removido com sucesso!");
        }
    }
}