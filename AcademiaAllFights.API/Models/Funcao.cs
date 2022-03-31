using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AcademiaAllFights.API.Models
{
    public class Funcao : IdentityRole<int>
    {
        public List<UsuarioFuncoes> UsuarioFuncoes { get; set; }
    }
}
