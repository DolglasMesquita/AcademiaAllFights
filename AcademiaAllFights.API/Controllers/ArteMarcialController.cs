using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaAllFights.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArteMarcialController : ControllerBase
    {

        private readonly IRepository _repository;

        public ArteMarcialController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var artesmarciais = _repository.GetAllArtesMarciais();
            if(artesmarciais == null) return BadRequest("Nenhuma arte marcial cadastrada!");

            return Ok(artesmarciais);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var artemarcial = _repository.GetArteMarcialById(id);
            if(artemarcial == null) return BadRequest("Arte Marcial não encontrada");

            return Ok(artemarcial);
        }

        [HttpPost]
        public IActionResult Post(ArteMarcial arteMarcial) {
            _repository.Add(arteMarcial);
            if(!_repository.SaveChanges()) return BadRequest("ArteMarcial não cadastrada");

            return Created("ArteMarcial criada com sucesso!", arteMarcial);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ArteMarcial arteMarcial) {
            var alu = _repository.GetArteMarcialById(id);
            if (alu == null) return BadRequest("ArteMarcial não encontrada");
            _repository.Update(arteMarcial);
            if(!_repository.SaveChanges()) return BadRequest("ArteMarcial não atualizada");
            return Ok("ArteMarcial atualizada com sucesso!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ArteMarcial arteMarcial) {
            var alu = _repository.GetArteMarcialById(id);
            if (alu == null) return BadRequest("ArteMarcial não encontrado");
            _repository.Update(arteMarcial);
            if(!_repository.SaveChanges()) return BadRequest("ArteMarcial não atualizado");
            return Ok("ArteMarcial atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var ArteMarcial = _repository.GetArteMarcialById(id);
            if (ArteMarcial == null) return BadRequest("ArteMarcial não encontrado");
            _repository.Delete(ArteMarcial);
            if(!_repository.SaveChanges()) return BadRequest("ArteMarcial não removido");
            return Ok("ArteMarcial removido com sucesso!");
        }
    }
}