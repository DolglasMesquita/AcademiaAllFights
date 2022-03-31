using AcademiaAllFights.API.Data;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace AcademiaAllFights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArteMarcialController : ControllerBase
    {

        private readonly IRepository _repository;

        public ArteMarcialController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var artesmarciais = await _repository.GetAllArtesMarciaisAsync();
            if(artesmarciais == null) return NotFound("Nenhuma arte marcial cadastrada!");

            return Ok(artesmarciais);
        }

        [HttpGet("status/{status:bool}")]
        public async Task<IActionResult> GetAllAtivo(bool status)
        {
            var artesmarciais = await _repository.GetAllArtesMarciaisAtivoAsync(status);
            if (artesmarciais == null) return NotFound("Nenhuma arte marcial cadastrada!");

            return Ok(artesmarciais);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var artemarcial = await _repository.GetArteMarcialByIdAsync(id);
            if(artemarcial == null) return NotFound("Arte Marcial não encontrada");

            return Ok(artemarcial);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(ArteMarcial arteMarcial) {
            _repository.Add(arteMarcial);
            if(await _repository.SaveChangesAsync()) return Created("ArteMarcial criada com sucesso!", arteMarcial); 
            
            return NotFound("ArteMarcial não cadastrada");
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, ArteMarcial arteMarcial) {
            var alu = await _repository.GetArteMarcialByIdAsync(id);
            if (alu == null) return BadRequest("ArteMarcial não encontrada");
            _repository.Update(arteMarcial);
            if(await _repository.SaveChangesAsync()) return Ok("ArteMarcial atualizada com sucesso!"); 
            
            return BadRequest("ArteMarcial não atualizada");
            
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Patch(int id, ArteMarcial arteMarcial) {
            var alu = await _repository.GetArteMarcialByIdAsync(id);
            if (alu == null) return BadRequest("ArteMarcial não encontrado");
            _repository.Update(arteMarcial);
            if(await _repository.SaveChangesAsync()) return Ok("ArteMarcial atualizado com sucesso!"); 
            
            return BadRequest("ArteMarcial não atualizado");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) {
            var ArteMarcial = await _repository.GetArteMarcialByIdAsync(id);
            if (ArteMarcial == null) return BadRequest("ArteMarcial não encontrado");
            _repository.Delete(ArteMarcial);
            if(await _repository.SaveChangesAsync()) return Ok("ArteMarcial removido com sucesso!"); 
            
            return BadRequest("ArteMarcial não removido");
        }
    }
}