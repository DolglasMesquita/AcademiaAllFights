using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AcademiaAllFights.API.Models
{
    public class Usuario : IdentityUser<int>
    {
        public string Nome { get; set; }
        public List<UsuarioFuncoes> UsuarioFuncoes { get; set; }

    }
}
