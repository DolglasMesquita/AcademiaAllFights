namespace AcademiaAllFights.API.Models
{
    public class ArteMarcial
    {
        public ArteMarcial()
        {

        }

        public ArteMarcial(int id, string nome, int professorId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

    }
}