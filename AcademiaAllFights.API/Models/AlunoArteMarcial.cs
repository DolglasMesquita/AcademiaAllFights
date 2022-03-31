using Newtonsoft.Json;

namespace AcademiaAllFights.API.Models
{
    public class AlunoArteMarcial
    {
        public AlunoArteMarcial()
        {

        }

        public AlunoArteMarcial(int alunoId, int arteMarcialId)
        {
            this.AlunoId = alunoId;
            this.ArteMarcialId = arteMarcialId;
        }

        public int AlunoId { get; set; }
        public int ArteMarcialId { get; set; }

        [JsonIgnore]
        public Aluno Aluno { get; set; }
        public ArteMarcial ArteMarcial { get; set; }

    }
}