
using Microsoft.AspNetCore.Identity;

namespace AcademiaAllFights.API.Models
{
    public class UsuarioFuncoes : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Funcao Funcao { get; set; }
    }
}
