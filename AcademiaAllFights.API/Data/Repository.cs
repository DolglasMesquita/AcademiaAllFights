using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<AlunoArteMarcial> GetAlunoArteMarcialAsync(int idAluno, int idArteMarcial)
        {
            IQueryable<AlunoArteMarcial> query = _context.AlunosArtesMarciais;
            query = query.Where(aluno => aluno.AlunoId == idAluno)
                         .Where(artemarcial => artemarcial.ArteMarcialId == idArteMarcial)
                         .AsNoTracking();

            return await query.FirstOrDefaultAsync();

        }

        public async Task<AlunoArteMarcial[]> GetAlunoArteMarcialAlunoAsync(int id)
        {
            IQueryable<AlunoArteMarcial> query = _context.AlunosArtesMarciais;
            query = query.Include(a => a.ArteMarcial).Where(a => a.AlunoId == id).AsNoTracking();

            return await query.ToArrayAsync();

        }


        public async Task<Aluno[]> GetAllAlunosAsync()
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArteMarcial)
            .AsNoTracking().OrderByDescending(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int id)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArteMarcial)
            .AsNoTracking().Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosByArteMarcialIdAsync(int id)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArteMarcial)
            .AsNoTracking().OrderByDescending(a => a.Id)
            .Where(a => a.AlunosArtesMarciais.Any(am => am.ArteMarcialId == id));

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync()
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.Include(p => p.ArteMarcial).AsNoTracking().OrderByDescending(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorByIdAsync(int id)
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.Include(p => p.ArteMarcial).Where(p => p.Id == id).AsNoTracking();
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<ArteMarcial[]> GetAllArtesMarciaisAsync()
        {
            IQueryable<ArteMarcial> query = _context.ArtesMarciais;
            query = query.AsNoTracking().OrderByDescending(am => am.Id);

            return await query.ToArrayAsync();

        }

        public async Task<ArteMarcial[]> GetAllArtesMarciaisAtivoAsync(bool status)
        {
            IQueryable<ArteMarcial> query = _context.ArtesMarciais;
            query = query.Where(am => am.Ativo == status).AsNoTracking().OrderByDescending(am => am.Id);

            return await query.ToArrayAsync();

        }

        public async Task<ArteMarcial> GetArteMarcialByIdAsync(int id)
        {
            IQueryable<ArteMarcial> query = _context.ArtesMarciais;
            query = query.Where(am => am.Id == id).AsNoTracking();
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosByStatusAsync(bool status)
        {
            IQueryable<Aluno> query = _context.Alunos;
            query = query.Include(a => a.AlunosArtesMarciais).ThenInclude(am => am.ArteMarcial)
                .Where(a => a.Ativo == status).AsNoTracking().OrderByDescending(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetProfessoresByStatusAsync(bool status)
        {
            IQueryable<Professor> query = _context.Professores;
            query = query.Include(p => p.ArteMarcial).Where(p => p.Ativo == status).AsNoTracking().OrderByDescending(p => p.Id);

            return await query.ToArrayAsync();
        }

    }
}
