using System.Linq;
using AcademiaAllFights.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaAllFights.API.Data
{
    public class Repository : IRepository
    {
        private readonly AllFightsContext _context;

        public Repository(AllFightsContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


        public Aluno[] GetAllAlunos()
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArtesMarciais)
            .ThenInclude(p => p.Professor).AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno GetAlunoById(int id)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArtesMarciais)
            .ThenInclude(p => p.Professor).AsNoTracking().Where(a => a.Id == id);

            return query.FirstOrDefault();
        }

        public Aluno[] GetAlunosByArteMarcialId(int id)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArtesMarciais)
            .ThenInclude(p => p.Professor).AsNoTracking().OrderBy(a => a.Nome)
            .Where(a => a.AlunosArtesMarciais.Any(am => am.ArteMarcialId == id));

            return query.ToArray();
        }

        public Professor[] GetAllProfessores()
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.Include(p => p.ArtesMarciais).AsNoTracking().OrderBy(p => p.Nome);

            return query.ToArray();
        }

        public Professor GetProfessorById(int id)
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.Include(p => p.ArtesMarciais).Where(p => p.Id == id).AsNoTracking();
            
            return query.FirstOrDefault();
        }

        public ArteMarcial[] GetAllArtesMarciais()
        {
            IQueryable<ArteMarcial> query = _context.ArtesMarciais;
            query = query.Include(am => am.Professor).AsNoTracking().OrderBy(am => am.Nome);

            return query.ToArray();

        }

        public ArteMarcial GetArteMarcialById(int id)
        {
            IQueryable<ArteMarcial> query = _context.ArtesMarciais;
            query = query.Include(am => am.Professor).Where(am => am.Id == id).AsNoTracking();
            
            return query.FirstOrDefault();
        }
    }
}
