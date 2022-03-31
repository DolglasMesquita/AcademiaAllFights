using AcademiaAllFights.API.Models;
using System.Threading.Tasks;

namespace AcademiaAllFights.API.Data
{
    public interface IRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public Task<bool> SaveChangesAsync();

        Task<AlunoArteMarcial> GetAlunoArteMarcialAsync(int idAluno, int idArteMarcial);
        Task<AlunoArteMarcial[]> GetAlunoArteMarcialAlunoAsync(int id);

        Task<Aluno[]> GetAllAlunosAsync();
        Task<Aluno[]> GetAlunosByStatusAsync(bool status);
        Task<Aluno[]> GetAlunosByArteMarcialIdAsync(int id);
        Task<Aluno> GetAlunoByIdAsync(int id);

        Task<Professor[]> GetAllProfessoresAsync();
        Task<Professor[]> GetProfessoresByStatusAsync(bool status);
        Task<Professor> GetProfessorByIdAsync(int id);

        Task<ArteMarcial[]> GetAllArtesMarciaisAsync();
        Task<ArteMarcial[]> GetAllArtesMarciaisAtivoAsync(bool status);
        Task<ArteMarcial> GetArteMarcialByIdAsync(int id);

        
    }
}