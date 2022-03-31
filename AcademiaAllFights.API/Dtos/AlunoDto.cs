using AcademiaAllFights.API.Models;
using System;
using System.Collections.Generic;

namespace AcademiaAllFights.API.Dtos
{
    public class AlunoDto
    {   
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<AlunoArteMarcial> AlunosArtesMarciais { get; set; }
    }
}
