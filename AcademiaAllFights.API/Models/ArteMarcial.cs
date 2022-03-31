namespace AcademiaAllFights.API.Models
{
    public class ArteMarcial
    {
        public ArteMarcial()
        {

        }

        public ArteMarcial(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;

    }
}