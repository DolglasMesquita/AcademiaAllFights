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
        public Aluno Aluno { get; set; }
        public ArteMarcial ArtesMarciais { get; set; }

    }
}