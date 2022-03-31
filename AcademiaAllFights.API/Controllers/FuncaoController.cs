using System;
using System.Threading.Tasks;
using AcademiaAllFights.API.Dtos;
using AcademiaAllFights.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaAllFights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly RoleManager<Funcao> _roleManager;
        private readonly UserManager<Usuario> _userManager;

        public FuncaoController(RoleManager<Funcao> roleManager, UserManager<Usuario> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> getFuncaoUsuario(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound("Usuário não encontrado");
            var roles = await _userManager.GetRolesAsync(user);

            return Ok(roles);
        }

        // POST: api/Role/CreateRole
        [HttpPost]
        public async Task<IActionResult> CreateRole(FuncaoDto roleDto)
        {
            try
            {
                var retorno = await _roleManager.CreateAsync(new Funcao { Name = roleDto.Name });

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserRoles(UpdateUsuarioFuncaoDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.UserName);

                if (user != null)
                {
                    if (model.Delete)
                        await _userManager.RemoveFromRoleAsync(user, model.Role);
                    else
                        await _userManager.AddToRoleAsync(user, model.Role);
                }
                else
                {
                    return Ok("Usuário não encontrado");
                }

                return Ok("Sucesso");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }
    }
}
