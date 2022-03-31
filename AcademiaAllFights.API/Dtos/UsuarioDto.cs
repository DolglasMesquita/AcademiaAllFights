using System.ComponentModel.DataAnnotations;

namespace AcademiaAllFights.API.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
