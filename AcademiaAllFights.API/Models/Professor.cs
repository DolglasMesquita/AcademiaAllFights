using System;
using System.Collections.Generic;


namespace AcademiaAllFights.API.Models
{
    public class Professor
    {

        public Professor()
        {
        }

        public Professor(int id, string nome, string cpf )
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<ArteMarcial> ArtesMarciais { get; set; }

    }
}