using System;
using System.ComponentModel.DataAnnotations;

namespace AcademiaAllFights.API.Models
{
    public class Professor
    {

        public Professor()
        {
        }

        public Professor(int id, string nome, string cpf, string telefone, int arteMarcialId)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            ArteMarcialId = arteMarcialId;


        }
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public int ArteMarcialId { get; set; }
        public ArteMarcial ArteMarcial { get; set; }

    }
}