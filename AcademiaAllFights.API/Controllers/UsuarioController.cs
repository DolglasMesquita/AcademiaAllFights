using AcademiaAllFights.API.Dtos;
using AcademiaAllFights.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaAllFights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IMapper _mapper;

        public UsuarioController(IConfiguration config, UserManager<Usuario> userManager, 
                                SignInManager<Usuario> signInManager, IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var users = await _userManager.Users.ToListAsync();

            if (users == null) return NotFound("Nenhum susuário cadastrado");

            return Ok(_mapper.Map<IEnumerable<UsuarioDto>>(users));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return NotFound("Nenhum susuário cadastrado");

            await _userManager.DeleteAsync(user);

            return Ok("Removido");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(usuarioLoginDto.UserName);

                var result = await _signInManager
                    .CheckPasswordSignInAsync(user, usuarioLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users
                            .FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

                    var userToReturn = _mapper.Map<UsuarioDto>(appUser);

                    return Ok(new
                    {
                        token = GenerateJWToken(appUser).Result,
                        user = userToReturn
                    });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }

        // POST api/<UsuarioController>
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Register(UsuarioDto usuarioDto)
        {

            try
            {
                var user = await _userManager.FindByNameAsync(usuarioDto.UserName);

                if (user == null)
                {
                    user = new Usuario
                    {
                        UserName = usuarioDto.UserName,
                        Nome = usuarioDto.Nome
                    };

                    var result = await _userManager.CreateAsync(user, usuarioDto.Password);

                    if (result.Succeeded)
                    {
                        return Created("Usuario criado com sucesso", usuarioDto.UserName);
                    
                    }
                   
                }

                return Ok("Usuário '" + user.UserName + "' já existe!" );
            }

            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"ERRO {e.Message}");
            }

        }

        private async Task<string> GenerateJWToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UserName)

            };

            var roles = await _userManager.GetRolesAsync(usuario);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
