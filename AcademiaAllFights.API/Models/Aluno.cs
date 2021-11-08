using System;
using System.Collections.Generic;

namespace AcademiaAllFights.API.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }

        public Aluno(int id, string nome, string cpf, string telefone, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoArteMarcial> AlunosArtesMarciais { get; set; }





    }
}