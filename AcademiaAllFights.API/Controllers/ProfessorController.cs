using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaAllFights.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var Professores = _repository.GetAllProfessores();
            return Ok(Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var Professor = _repository.GetProfessorById(id);
            if(Professor == null) return BadRequest("Professor não encontrado!");

            return Ok(Professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor) {
            _repository.Add(professor);
            if(!_repository.SaveChanges()) return BadRequest("Professor não cadastrado");

            return Created("Professor criado com sucesso!", professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor) {
            var alu = _repository.GetProfessorById(id);
            if (alu == null) return BadRequest("Professor não encontrado");
            _repository.Update(professor);
            if(!_repository.SaveChanges()) return BadRequest("Professor não atualizado");
            return Ok("Professor atualizado com sucesso!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor) {
            var alu = _repository.GetProfessorById(id);
            if (alu == null) return BadRequest("Professor não encontrado");
            _repository.Update(professor);
            if(!_repository.SaveChanges()) return BadRequest("Professor não atualizado");
            return Ok("Professor atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var Professor = _repository.GetProfessorById(id);
            if (Professor == null) return BadRequest("Professor não encontrado");
            _repository.Delete(Professor);
            if(!_repository.SaveChanges()) return BadRequest("Professor não removido");
            return Ok("Professor removido com sucesso!");
        }
    }
}