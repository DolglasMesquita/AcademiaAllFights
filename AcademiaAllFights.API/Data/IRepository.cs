using AcademiaAllFights.API.Models;

namespace AcademiaAllFights.API.Data
{
    public interface IRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public bool SaveChanges();

        Aluno[] GetAllAlunos();
        Aluno[] GetAlunosByArteMarcialId(int id);
        Aluno GetAlunoById(int id);

        Professor[] GetAllProfessores();
        Professor GetProfessorById(int id);

        ArteMarcial[] GetAllArtesMarciais();
        ArteMarcial GetArteMarcialById(int id);

        
    }
}