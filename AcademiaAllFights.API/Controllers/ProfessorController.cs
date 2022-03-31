using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AcademiaAllFights.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var Professores = await _repository.GetAllProfessoresAsync();
            if (Professores == null) return NotFound("Nenhum professor cadastrado");

            return Ok(Professores);
        }

        [HttpGet("status/{status:bool}")]
        public async Task<IActionResult> GetAtivos(bool status)
        {
            var professores = await _repository.GetProfessoresByStatusAsync(status);

            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Professor = await _repository.GetProfessorByIdAsync(id);
            if (Professor == null) return BadRequest("Professor não encontrado!");

            return Ok(Professor);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(Professor professor) {
            _repository.Add(professor);
            if(await _repository.SaveChangesAsync()) return Created("Professor criado com sucesso!", professor);

            return BadRequest("Professor não cadastrado");
            
        }

        [HttpPatch("desativar/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Desativar(int id)
        {
            var professor = await _repository.GetProfessorByIdAsync(id);
            if (professor == null) return NotFound("Professor não encontrado");
            if (professor.Ativo)
            {
                professor.Ativo = false;
                professor.DataFim = DateTime.Now;

            } else
            {
                BadRequest("O professor já está inativo");
            }
            
            _repository.Update(professor);
            if (await _repository.SaveChangesAsync()) return Ok("Professor desativado com sucesso!");

            return BadRequest("Não foi possível desativar o professor");
        }

        [HttpPatch("ativar/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ativar(int id)
        {
            var professor = await _repository.GetProfessorByIdAsync(id);
            if (professor == null) return BadRequest("Professor não encontrado");
            if (!professor.Ativo)
            {
                professor.Ativo = true;
                professor.DataFim = null;
            }
            else
            {
                BadRequest("O professor já está ativo");
            }
            _repository.Update(professor);
            if (await _repository.SaveChangesAsync()) return Ok("Professor ativado com sucesso!"); 

            return BadRequest("Não foi possível ativar o professor");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, Professor professor) {
            var alu = await _repository.GetProfessorByIdAsync(id);
            if (alu == null) return BadRequest("Professor não encontrado");
            _repository.Update(professor);
            if(await _repository.SaveChangesAsync()) return Ok("Professor atualizado com sucesso!"); 
            
            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Patch(int id, Professor professor) {
            var alu = await _repository.GetProfessorByIdAsync(id);
            if (alu == null) return BadRequest("Professor não encontrado");
            _repository.Update(professor);
            if(await _repository.SaveChangesAsync()) return Ok("Professor atualizado com sucesso!"); 

            return BadRequest("Professor não atualizado");   
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var Professor = await _repository.GetProfessorByIdAsync(id);
            if (Professor == null) return BadRequest("Professor não encontrado");
            _repository.Delete(Professor);
            if(await _repository.SaveChangesAsync()) return Ok("Professor removido com sucesso!"); 

            return BadRequest("Professor não removido");
        }
    }
}