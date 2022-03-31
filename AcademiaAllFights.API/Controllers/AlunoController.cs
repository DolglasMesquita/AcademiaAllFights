using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Dtos;
using AcademiaAllFights.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaAllFights.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var alunos = await _repository.GetAllAlunosAsync();
            if (alunos == null) return NotFound("Nenhum professor cadastrado");
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("status/{status:bool}")]
        public async Task<IActionResult> GetAtivos(bool status)
        {
            var alunos = await _repository.GetAlunosByStatusAsync(status);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var aluno = await _repository.GetAlunoByIdAsync(id);
            if(aluno == null) return BadRequest("Aluno não encontrado!");


            //return Ok(_mapper.Map<AlunoDto>(aluno));
            return Ok(aluno);
        }

        [HttpGet("artemarcial/{id}")]
        public  async Task<IActionResult> GetByArteMarcial(int id)
        {
            var alunos = await _repository.GetAlunosByArteMarcialIdAsync(id);
            return Ok(alunos);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(Aluno aluno) {
            _repository.Add(aluno);
            if(await _repository.SaveChangesAsync()) return Created("Aluno criado com sucesso!", aluno);

            return NotFound("Aluno não cadastrado");
        }

        [HttpPatch("desativar/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Desativar(int id)
        {
            var aluno = await _repository.GetAlunoByIdAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado");
            if(aluno.Ativo)
            {
                aluno.Ativo = false;
                aluno.DataFim = DateTime.Now;
            } else
            {
                return BadRequest("O aluno já está inativo");
            }
            
            _repository.Update(aluno);
            if(await _repository.SaveChangesAsync()) return Ok("Aluno desativado com sucesso!"); ;
            return BadRequest("Não foi possível desativar o aluno");
        }

        [HttpPatch("ativar/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ativar(int id)
        {
            var aluno = await _repository.GetAlunoByIdAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado");
            if (aluno.Ativo)
            {
                aluno.Ativo = false;
                aluno.DataFim = null;
            } else
            {
                BadRequest("O aluno já esta ativo");
            }

            aluno.Ativo = true;
            _repository.Update(aluno);
            if (await _repository.SaveChangesAsync()) return Ok("Aluno ativado com sucesso!");
            return BadRequest("Não foi possível ativar o aluno");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, Aluno aluno) {
            var alu = await _repository.GetAlunoByIdAsync(id);
            if (alu == null) return NotFound("Aluno não encontrado");
            _repository.Update(aluno);
            if(await _repository.SaveChangesAsync()) return Ok("Aluno atualizado com sucesso!");
            return BadRequest("Aluno não atualizado");
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Patch(int id, Aluno aluno) {
            var alu = await _repository.GetAlunoByIdAsync(id);
            if (alu == null) return NotFound("Aluno não encontrado");
            _repository.Update(aluno);
            if (await _repository.SaveChangesAsync()) return Ok("Aluno atualizado com sucesso!");
            return BadRequest("Aluno não atualizado"); ;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var aluno = await _repository.GetAlunoByIdAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado");
            _repository.Delete(aluno);
            if (await _repository.SaveChangesAsync()) return Ok("Aluno removido com sucesso!");
            return BadRequest("Aluno não removido");
        }
    }
}